using ProjetSessionBackend.Core.Models.DTOs;

namespace ProjetSessionBackend.Core.Interfaces.Repositories;

public interface IUserRepository
{
    List<UserResponse> GetAll();
}