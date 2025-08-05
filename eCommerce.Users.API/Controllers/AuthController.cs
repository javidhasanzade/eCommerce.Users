using eCommerce.Users.Core.Dtos;
using eCommerce.Users.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Users.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("login")]
    public async Task<IActionResult?> Login(LoginRequest loginRequest)
    {
        var authResponse = await _userService.LoginAsync(loginRequest);
        
        if (authResponse == null || !authResponse.Success)
            return Unauthorized(authResponse);
        
        return Ok(authResponse);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest registerRequest)
    {
        if (registerRequest == null)
            return BadRequest("Invalid registration request");

        var authResponse = await _userService.RegisterAsync(registerRequest);
        
        if (authResponse == null || !authResponse.Success)
            return BadRequest(authResponse);
        
        return Ok(authResponse);
    }
}