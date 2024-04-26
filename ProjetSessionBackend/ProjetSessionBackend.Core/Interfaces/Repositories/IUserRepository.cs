using ProjetSessionBackend.Core.Database.Models;

namespace ProjetSessionBackend.Core.Interfaces.Repositories;

public interface IUserRepository
{
    public IEnumerable<User> GetAll();
    public User? GetById(int id);
    public User Create(User user);
    public User? Delete(int id);
}