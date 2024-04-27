using ProjetSessionBackend.Core.Models.Entities;

namespace ProjetSessionBackend.Core.Interfaces.Repositories;

public interface IRoleRepository
{
    public Task<IEnumerable<Role>> GetAll();
    public Task<Role?> GetById(int id);
}