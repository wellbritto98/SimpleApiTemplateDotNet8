using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Asn1.Ocsp;
using SimpleApiTemplate.Data.Dtos;

namespace SimpleApiTemplate.Services;

public class JwtService
{
    private IConfiguration _configuration;

    public JwtService(IConfiguration configuration)
    {
        _configuration = configuration;

    }
    public string GenerateToken(JwtDto dto)
    {
        var secretKey = _configuration["JwtConfig:Secret"];
        Claim[] claims = new Claim[]
        {
            new Claim(ClaimTypes.Email, dto.Email),
            new Claim("id", dto.Id),
            new Claim(ClaimTypes.Role, dto.Role)
        };

        var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var signingCredentials = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256Signature);

        var token = new JwtSecurityToken
        (
            expires: DateTime.Now.AddDays(7),
            claims: claims,
            signingCredentials: signingCredentials
        );

        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
        return tokenString;
    }



    public bool VerifyJwt(string token)
    {
        var secretKey = _configuration["JwtConfig:Secret"];
        var tokenHandler = new JwtSecurityTokenHandler();
        var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = chave,
                ValidateIssuer = false,
                ValidateAudience = false
            }, out SecurityToken validatedToken);

            return true;
        }
        catch
        {
            return false;
        }
    }

    
}