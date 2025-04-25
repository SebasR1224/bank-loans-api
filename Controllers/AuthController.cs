using Microsoft.AspNetCore.Mvc;
using BankLoans.Services;
using API.DTOs;
using Microsoft.AspNetCore.Authorization;
using BankLoans.DTOs;

namespace BankLoans.Controllers;

[ApiController]
[Route("api/[controller]")]
[AllowAnonymous]
public class AuthController(IAuthService authService) : ControllerBase
{

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var user = await authService.LoginAsync(request.Email, request.Password);
        if (user == null)
            return Unauthorized();

        var token = authService.GenerateJwtToken(user);
        return Ok(new LoginResponse(token, new UserResponse(user.Id, user.Email, user.Role)));
    }
}

