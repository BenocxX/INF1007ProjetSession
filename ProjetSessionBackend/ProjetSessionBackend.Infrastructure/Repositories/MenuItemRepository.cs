using ProjetSessionBackend.Core.Interfaces.Repositories;
using ProjetSessionBackend.Core.Models.Entities;

namespace ProjetSessionBackend.Infrastructure.Repositories;

public class MenuItemRepository : IMenuItemRepository
{
    public Task<IEnumerable<MenuItem>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<MenuItem?> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<MenuItem> Create(MenuItem entity)
    {
        throw new NotImplementedException();
    }

    public Task<MenuItem?> Delete(int id)
    {
        throw new NotImplementedException();
    }
}