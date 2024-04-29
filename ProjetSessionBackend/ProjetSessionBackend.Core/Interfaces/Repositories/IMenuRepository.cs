using ProjetSessionBackend.Core.Models.Entities;

namespace ProjetSessionBackend.Core.Interfaces.Repositories;

public interface IMenuRepository
{
    public Task<IEnumerable<Menu>> GetAll();
    public Task<Menu?> GetById(int id);
    public Task<Menu> Create(Menu menu);
    public Task<Menu?> CreateWithExistingMenuItems(Menu menu, List<int> ids);
    public Task<Menu?> Delete(int id);
    public Task<Menu> Update(Menu menu, List<int> ids);
}