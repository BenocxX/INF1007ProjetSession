using ProjetSessionBackend.Core.Models.Entities;

namespace ProjetSessionBackend.Core.Interfaces.Repositories;

public interface IUserRepository
{
    public Task<IEnumerable<User>> GetAll();
    public Task<User?> GetById(int id);
    public Task<User?> GetUserByEmail(string email);
    public Task<User> Create(User user);
    public Task<User?> Delete(int id);
}