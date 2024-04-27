using ProjetSessionBackend.Core.Models.DTOs.Auth;
using ProjetSessionBackend.Core.Models.Entities;

namespace ProjetSessionBackend.Core.Interfaces.Services;

public interface IAuthService
{
    public AuthResponse? Login(User user, string password);
    public Task<AuthResponse> Register(User user);
}