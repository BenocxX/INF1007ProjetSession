using ProjetSessionBackend.Core.Models.DTOs;
using ProjetSessionBackend.Core.Models.Entities;

namespace ProjetSessionBackend.Core.Interfaces.Repositories;

public interface IMenuRepository
{
    List<Menu> GetAll();

    Menu? GetById(int id);

    void DeleteById(int id);

    void insert(Menu menu);

    void update(Menu menu);
}