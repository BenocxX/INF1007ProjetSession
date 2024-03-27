using ProjetSessionBackend.Core.Models.Entities;

namespace ProjetSessionBackend.Core.Interfaces.Repositories;

public interface IUserRepository
{
    List<User> GetAll();
}