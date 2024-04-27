using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProjetSessionBackend.Core.Database.Models;
using ProjetSessionBackend.Core.DTOs.Auth;
using ProjetSessionBackend.Core.Interfaces.Repositories;
using ProjetSessionBackend.Core.Interfaces.Services;

namespace ProjetSessionBackend.Core.Services;

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;
    private readonly IHashService _hashService;
    private readonly IUserRepository _userRepository;

    public AuthService(
        IConfiguration configuration, 
        IHashService hashService, 
        IUserRepository userRepository)
    {
        _configuration = configuration;
        _hashService = hashService;
        _userRepository = userRepository;
    }

    public AuthResponse? Login(User user, string password)
    {
        if (!_hashService.Compare(password, user.Password))
            return null;
        
        var token = GenerateJsonWebToken(user);
        
        return new AuthResponse
        {
            Token = token
        };
    }

    public async Task<AuthResponse> Register(User user)
    {
        user.RoleId = Role.User;
        var createdUser = await _userRepository.Create(user);
        
        var token = GenerateJsonWebToken(createdUser);
        return new AuthResponse { Token = token };
    }

    private string GenerateJsonWebToken(User user)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.Firstname),
        };
        
        var jwtKey = _configuration["Jwt:Key"];
        var issuer = _configuration["Jwt:Issuer"];
        var audience = _configuration["Jwt:Issuer"];
        
        if (jwtKey == null)
            throw new Exception("Jwt key is not set");
        
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(30),
            SigningCredentials = credentials,
            Issuer = issuer,
            Audience = audience,
            IssuedAt = DateTime.Now.AddMinutes(120),
            NotBefore = DateTime.Now.AddMinutes(120),
            Claims = new Dictionary<string, object>
            {
                { "role", Role.GetRoleName(user.RoleId) }
            }
        };
        
        Console.WriteLine(tokenDescriptor);
        
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        
        return tokenHandler.WriteToken(token);
    }
}