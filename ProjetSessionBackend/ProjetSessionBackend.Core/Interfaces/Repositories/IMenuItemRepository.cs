using AutoMapper;
using ProjetSessionBackend.Core.Models.Entities;

namespace ProjetSessionBackend.Core.Interfaces.Repositories;

public interface IMenuItemRepository
{
    public Task<IEnumerable<MenuItem>> GetAll();
    public Task<MenuItem?> GetById(int id);
    public Task<MenuItem> Create(MenuItem menuItem);
    public Task<MenuItem?> Delete(int id);
}