using ProjetSessionBackend.Core.Models.DTOs;
// using ProjetSessionBackend.Core.Models.Entities;

namespace ProjetSessionBackend.Core.Interfaces.Repositories;

public interface IUsersRepository
{
    List<UserResponse> GetAll();
}