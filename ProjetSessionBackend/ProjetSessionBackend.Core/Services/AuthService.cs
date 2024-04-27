using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProjetSessionBackend.Core.Interfaces.Repositories;
using ProjetSessionBackend.Core.Interfaces.Services;
using ProjetSessionBackend.Core.Models.DTOs.Auth;
using ProjetSessionBackend.Core.Models.Entities;

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
        
        var token = GenerateJwtToken(user);
        
        return new AuthResponse
        {
            Token = token
        };
    }

    public async Task<AuthResponse> Register(User user)
    {
        user.RoleId = Role.User;
        var createdUser = await _userRepository.Create(user);
        
        var token = GenerateJwtToken(createdUser);
        return new AuthResponse { Token = token };
    }
    
    public string GenerateJwtToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = _configuration["Jwt:Key"];

        if (key == null)
            throw new Exception("Jwt key is not set");
        
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new(ClaimTypes.Email, user.Email),
                new(ClaimTypes.Role, user.Role.Name)
            }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}