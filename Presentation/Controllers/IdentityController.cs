using BusinessLogic.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Presentation.DTOs;
using Presentation.Jwt;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IdentityController(IIdentityService service) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] UserDto userDto)
    {
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(userDto.Password);
        var existingUser = await service.GetUser(userDto.Username);

        if (existingUser is not null)
            return BadRequest("Username is taken");

        var user = new User(userDto.Username, passwordHash);
        return Ok("UserId: " + await service.CreateUser(user));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserDto userDto)
    {
        var claims = await service.Login(userDto.Username, userDto.Password);

        var token = JwtHandler.GenerateAccessToken(claims);
        var accessToken = new AccessTokenDto(token);
        return Ok(accessToken);
    }
}
