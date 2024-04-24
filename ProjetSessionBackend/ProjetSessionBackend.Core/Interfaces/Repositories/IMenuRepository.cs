using ProjetSessionBackend.Core.Models.DTOs;
using ProjetSessionBackend.Core.Models.Entities;

// using ProjetSessionBackend.Core.Models.Entities;

namespace ProjetSessionBackend.Core.Interfaces.Repositories;

public interface IMenuRepository
{
    List<Menu> GetAll();

    Menu GetById(int id);
    
    void DeleteById(int id);

    void insert(MenuResponse menu);

    void update(MenuResponse menu);
}