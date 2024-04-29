using ProjetSessionBackend.Core.Models.Entities;

namespace ProjetSessionBackend.Core.Interfaces.Repositories;

public interface IOrderRepository
{
    public Task<IEnumerable<Order>> GetAll();
    public Task<Order?> GetById(int id);
    public Task<IEnumerable<Order>> GetByUserId(int userId);
    public Task<Order> Create(Order order);
    public Task<Order?> Delete(int id);
    
    public Task<Order> Update(Order order);
}