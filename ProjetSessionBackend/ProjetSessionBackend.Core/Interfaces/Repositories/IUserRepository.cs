using ProjetSessionBackend.Core.Models.Entities;

namespace ProjetSessionBackend.Core.Interfaces.Repositories;

public interface IUserRepository : IEntityRepository<User>
{
    public Task<User?> GetUserByEmail(string email);
}