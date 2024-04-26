using ProjetSessionBackend.Core.Database.Models;

namespace ProjetSessionBackend.Core.Interfaces.Repositories;

public interface IRoleRepository
{
    public Task<IEnumerable<Role>> GetAll();
    public Task<Role?> GetById(int id);
}