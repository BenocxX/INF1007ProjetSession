using ProjetSessionBackend.Core.Models.DTOs;
// using ProjetSessionBackend.Core.Models.Entities;

namespace ProjetSessionBackend.Core.Interfaces.Repositories;

public interface IAuthRepository
{
    Task<User> Register(User user);

    Task<User?> Login(UserLoginResponse userLoginResponse);
}