using ProjetSessionBackend.Core.Database.Models;

namespace ProjetSessionBackend.Core.Interfaces.Repositories;

public interface IRoleRepository
{
    public IEnumerable<Role> GetAll();
    public Role? GetById(int id);
}