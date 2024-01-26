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

    [HttpPost(nameof(Authenticate))]
    public IActionResult Authenticate(AuthCommandDto request)
    {
        var user = _usersService.GetUserByUsernameAndPassword(request.Username, request.Password);

        if (user == null)
        {
            return BadRequest("Invalid credentials");
        }

        var claims = Claims(user);

        var signIn = SigningCredentials();

        var token = Token(claims, signIn);

        return Ok(new JwtSecurityTokenHandler().WriteToken(token));
    }

    private SigningCredentials SigningCredentials()
    {
        var bytes = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? throw new Exception());
        var key = new SymmetricSecurityKey(bytes);
        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        return signIn;
    }

    private JwtSecurityToken Token(Claim[] claims, SigningCredentials signingCredentials)
    {
        var issuer = _configuration["Jwt:Issuer"] ?? throw new Exception();
        var audience = _configuration["Jwt:Audience"] ?? throw new Exception();
        DateTime? expires = DateTime.UtcNow.AddMinutes(60);
        
        return new JwtSecurityToken(
            issuer,
            audience,
            claims,
            expires,
            signingCredentials);
    }

    private static Claim[] Claims(object user)
    {
        Claim[] claims =
        {
            new(JwtRegisteredClaimNames.Sub, user.Username),
            new(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToFileTimeUtc().ToString()),
        };
        return claims;
    }
}