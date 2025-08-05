using eCommerce.Users.Core.Dtos;
using eCommerce.Users.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Users.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(IUserService userService) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult?> Login(LoginRequest loginRequest)
    {
        var authResponse = await userService.LoginAsync(loginRequest);
        
        if (authResponse is not { Success: true })
            return Unauthorized(authResponse);
        
        return Ok(authResponse);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest registerRequest)
    {
        if (registerRequest == null)
            return BadRequest("Invalid registration request");

        var authResponse = await userService.RegisterAsync(registerRequest);
        
        if (authResponse is not { Success: true })
            return BadRequest(authResponse);
        
        return Ok(authResponse);
    }
}