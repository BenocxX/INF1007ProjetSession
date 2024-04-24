using ProjetSessionBackend.Core.Models.DTOs;
// using ProjetSessionBackend.Core.Models.Entities;

namespace ProjetSessionBackend.Core.Interfaces.Repositories;

public interface IAuthRepository
{
    Task<int> Register(RegisterResponse register);

    Task<Person?> Login(UserLoginResponse userLoginResponse);
}