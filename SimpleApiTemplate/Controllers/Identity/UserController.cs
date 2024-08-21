using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using SimpleApiTemplateDotNet8.Data.Dtos.Auth;
using SimpleApiTemplateDotNet8.Services.Interfaces;

namespace SimpleApiTemplate.Web.Controllers.Identity;

public class UserController : ControllerBase
{
    private IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("RegisterUser")]

    public async Task<IActionResult> Register([FromBody] RegisterUserDto registerUserDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _userService.RegisterUser(registerUserDto);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpPost("LoginUser")]
    public async Task<IActionResult> Login([FromBody] LoginUserDto loginUserDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _userService.LoginUser(loginUserDto);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpPost("RefreshToken")]
    [Authorize]
    public async Task<IActionResult> RefreshToken()
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _userService.RefreshToken();
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
}