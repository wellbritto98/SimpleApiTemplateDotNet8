using System.Security.Cryptography;
using System.Text;
using System.Web;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Newtonsoft.Json;
using SimpleApiTemplate.Data.Dtos;
using SimpleApiTemplate.Models;

namespace SimpleApiTemplate.Services;

public class UserService
{
    private IEmailSender _emailSender;
    private IMapper _mapper;
    private UserManager<User> _userManager;
    private SignInManager<User> _signInManager;
    private IHttpContextAccessor _httpContextAccessor;
    private HttpClient _httpClient;
    private JwtService _jwtService;

    public UserService(IMapper mapper, UserManager<User> userManager,
        SignInManager<User> signInManager, IHttpContextAccessor httpContextAccessor, IEmailSender emailSender,
        HttpClient httpClient, JwtService jwtService)
    {
        _mapper = mapper;
        _userManager = userManager;
        _signInManager = signInManager;
        _httpContextAccessor = httpContextAccessor;
        _emailSender = emailSender;
        _httpClient = httpClient;
        _jwtService = jwtService;
    }

    //cadastrar usuario
    public async Task<ApiResponse> RegisterUser(RegisterUserDto dto)
    {
        User user = _mapper.Map<User>(dto);
        user.UserName = user.Email;
        user.Email = user.Email.ToLower();
        user.RegisteredAt = DateTime.UtcNow;
        var today = DateTime.Today;
        var age = today.Year - user.DataNascimento.Year;

        // Ajusta a idade se o aniversário ainda não ocorreu este ano
        if (user.DataNascimento.Date > today.AddYears(-age)) age--;

        if (age < 18)
        {
            return new ApiResponse { Success = false, Message = "Usuário menor de idade!" };
        }


        if (!dto.AgreeTerms)
        {
            return new ApiResponse
            {
                Success = false,
                Message = "Infelizmente só podemos cadastrar usuários que aceitam os termos de uso."
            };
        }

        else
        {
            IdentityResult resultado = await _userManager.CreateAsync(user, dto.Password);

            if (!resultado.Succeeded)
            {
                var errors = resultado.Errors.Select(e => e.Description);
                return new ApiResponse
                    { Success = false, Message = $"Falha ao cadastrar usuário: {string.Join(", ", errors)}" };
            }

            var endpoint = "https://localhost:7225/resendConfirmationEmail";
            var payload = new { email = user.Email };
            var json = JsonConvert.SerializeObject(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(endpoint, content);

            if (response.IsSuccessStatusCode)
            {
                return new ApiResponse
                {
                    Success = true,
                    Message = "Usuário cadastrado com sucesso! Verifique sua conta no link que enviamos por email"
                };
            }
            else
            {
                return new ApiResponse
                {
                    Success = false,
                    Message = "Falha ao enviar email de confirmação"
                };
            }
        }
    }

    //logar usuario

    public async Task<ApiResponse> LoginUser(LoginUserDto dto)
    {
        var user = await _userManager.FindByEmailAsync(dto.Email);
        if (user == null)
        {
            return new ApiResponse { Success = false, Message = "Usuário não encontrado" };
        }
        else if (user.EmailConfirmed != true)
        {
            return new ApiResponse { Success = false, Message = "Email não confirmado" };
        }

        var resultado = await _signInManager.PasswordSignInAsync(user, dto.Password, false, true);

        if (resultado.Succeeded)
        {
            var token = _jwtService.GenerateToken(new JwtDto { Email = user.Email, Id = user.Id });
            _httpContextAccessor.HttpContext.Response.Cookies.Append("jwt", token, new CookieOptions
            {
                HttpOnly = true,
                SameSite = SameSiteMode.None,
                Secure = true
            });

            var refreshToken = GenerateRefreshToken();
            SetRefreshTokenInCookie(refreshToken);

            return new ApiResponse
            {
                Success = true, Message = "Usuário logado com sucesso",
                Data = new { Token = token, RefreshToken = refreshToken }
            };
        }
        else
        {
            return new ApiResponse { Success = false, Message = "Falha ao logar usuário" };
        }
    }

    private RefreshToken GenerateRefreshToken()
    {
        var refreshToken = new RefreshToken
        {
            Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
            Expired = DateTime.Now.AddDays(7)
        };
        return refreshToken;
    }

    private void SetRefreshTokenInCookie(RefreshToken refreshToken)
    {
        var user = _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User).Result;
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            SameSite = SameSiteMode.None,
            Secure = true,
            Expires = refreshToken.Expired
        };
        _httpContextAccessor.HttpContext.Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);
        if (user != null)
        {
            user.RefreshToken = refreshToken.Token;
            user.TokenCreatedAt = refreshToken.CreatedAt;
            user.TokenExpiredAt = refreshToken.Expired;
            _userManager.UpdateAsync(user);
        }
    }
}