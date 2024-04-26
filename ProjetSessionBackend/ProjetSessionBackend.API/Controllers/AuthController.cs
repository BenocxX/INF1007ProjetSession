using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProjetSessionBackend.Core.Interfaces.Repositories;
using ProjetSessionBackend.Core.Models.DTOs;
using ProjetSessionBackend.Core.Models.Entities;

namespace ProjetSessionBackend.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController: ControllerBase
{
    private readonly IAuthRepository _repository;
    private readonly IConfiguration _configuration;
    
    public AuthController(IAuthRepository repository, IConfiguration configuration)
    {
        _repository = repository;
        _configuration = configuration;
    }
    
    [HttpPost]
    [Route("/login")]
    public async Task<IActionResult> Login([FromBody] UserLoginResponse userLoginDto)
    {
        var person = await _repository.Login(userLoginDto);
       
        if (person?.User == null) 
            return Unauthorized();
        
        var tokenString = GenerateJsonWebToken(person);
        return Ok(new { token = tokenString });
    }

    [HttpPost]
    [Route("/register")]
    public async Task<ActionResult<int>> Register([FromBody] RegisterResponse register)
    {
        if (register == null)
            return BadRequest("Register is null");
        
        var personId = await _repository.Register(register);
        return Ok(personId);
    }
    
    private string GenerateJsonWebToken(Person person)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, person.Firstname!),
        };
        
        var jwtKey = _configuration["Jwt:Key"];
        
        if (jwtKey == null)
            throw new Exception("Jwt key is not set");
        
        var tokenHandler = new JwtSecurityTokenHandler();
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        
        var roleName = person.User?.Role?.Name;
        if (roleName == null)
            throw new Exception("Role is not set");

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(30),
            SigningCredentials = credentials,
            Issuer = _configuration["Jwt:Issuer"],
            Audience = _configuration["Jwt:Issuer"],
            IssuedAt = DateTime.Now.AddMinutes(120),
            NotBefore = DateTime.Now.AddMinutes(120),
            Claims = new Dictionary<string, object> { { "role", roleName } }
        };
        
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}