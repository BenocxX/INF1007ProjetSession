// using ProjetSessionBackend.Core.Models.Entities;

namespace ProjetSessionBackend.Core.Interfaces.Repositories;

public interface IMenuItemRepository
{
    List<MenuItem> GetAll();

    MenuItem? GetById(int id);

    void DeleteById(int id);

    void insert(MenuItem menuItem);

    void update(MenuItem menuItem);
}