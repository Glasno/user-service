using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Glasno.User.Service.Domain.Services;
using Glasno.User.Service.Presentation.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Glasno.User.Service.Presentation.Controllers;

[ApiController]
[Route("api/auth/")]
public class AuthController : ControllerBase
{
    private IConfiguration _configuration;
    private UserService _usersService;

    public AuthController(IConfiguration configuration, UserService usersService)
    {
        _configuration = configuration;
        _usersService = usersService;
    }

    [HttpPost("authenticate")]
    public IActionResult Post(AuthDto request)
    {
        var user = _usersService.GetUserByUsernameAndPassword(request.Username, request.Password);

        if (user == null)
        {
            return BadRequest("Invalid credentials");
        }

        Claim[] claims =
        {
            new(JwtRegisteredClaimNames.Sub, user.Username),
            new(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToFileTimeUtc().ToString()),
        };

        SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        SigningCredentials signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        JwtSecurityToken token = new JwtSecurityToken(
            _configuration["Jwt:Issuer"],
            _configuration["Jwt:Audience"],
            claims,
            expires: DateTime.UtcNow.AddMinutes(60),
            signingCredentials: signIn);

        return Ok(new JwtSecurityTokenHandler().WriteToken(token));
    }
}