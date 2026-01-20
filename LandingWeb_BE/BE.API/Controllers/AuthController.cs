using BE.API.DTOs;
using BE.BOs.Models;
using BE.REPOs.Interface;
using BE.REPOs.Service;
using Microsoft.AspNetCore.Mvc;

namespace BE.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserRepo _userRepo;
    private readonly AuthService _authService;

    public AuthController(IUserRepo userRepo, AuthService authService)
    {
        _userRepo = userRepo;
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var existingUser = await _userRepo.GetUserByEmailAsync(request.Email);
        if (existingUser != null)
            return BadRequest(new { message = "Email already exists" });

        var user = new User
        {
            Email = request.Email,
            PasswordHash = _authService.HashPassword(request.Password),
            FullName = request.FullName,
            PhoneNumber = request.PhoneNumber,
            Role = "Customer"
        };

        await _userRepo.CreateUserAsync(user);
        var token = _authService.GenerateJwtToken(user);

        return Ok(new { token, user = new { user.UserId, user.Email, user.FullName, user.Role } });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var user = await _userRepo.GetUserByEmailAsync(request.Email);
        if (user == null || !_authService.VerifyPassword(request.Password, user.PasswordHash))
            return Unauthorized(new { message = "Invalid credentials" });

        if (!user.IsActive)
            return Unauthorized(new { message = "Account is disabled" });

        var token = _authService.GenerateJwtToken(user);
        return Ok(new { token, user = new { user.UserId, user.Email, user.FullName, user.Role } });
    }
}
