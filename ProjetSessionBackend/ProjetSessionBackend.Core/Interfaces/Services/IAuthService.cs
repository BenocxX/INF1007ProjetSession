using ProjetSessionBackend.Core.Database.Models;
using ProjetSessionBackend.Core.DTOs.Auth;

namespace ProjetSessionBackend.Core.Interfaces.Services;

public interface IAuthService
{
    public AuthResponse? Login(User user, string password);
    public Task<AuthResponse> Register(User user);
}