using ProjetSessionBackend.Core.Models.DTOs;

namespace ProjetSessionBackend.Core.Interfaces.Repositories;

public interface IUsersRepository
{
    List<UserResponse> GetAll();
}