using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjetSessionBackend.Core.Interfaces.Repositories;
using ProjetSessionBackend.Core.Models.Entities;

namespace ProjetSessionBackend.Infrastructure.Repositories;

public class OrderRepository : BaseRepository, IOrderRepository
{
    public OrderRepository(ApplicationDbContext context, IMapper mapper) 
        : base(context, mapper) { }

    public async Task<IEnumerable<Order>> GetAll()
    {
        return await Db.Orders
            .Include(o => o.ClientBillingInfo)
            .ToListAsync();
    }

    public async Task<Order?> GetById(int id)
    {
        return await Db.Orders
            .Include(o => o.ClientBillingInfo)
            .FirstOrDefaultAsync(o => o.OrderId == id);
    }

    public async Task<IEnumerable<Order>> GetByUserId(int userId)
    {
        return await Db.Orders
            .Include(o => o.ClientBillingInfo)
            .Where(o => o.ClientBillingInfo.UserId == userId)
            .ToListAsync();
    }

    public async Task<Order> Create(Order order)
    {
        await Db.Orders.AddAsync(order);
        await Db.SaveChangesAsync();
        return order;
    }

    public async Task<Order?> Delete(int id)
    {
        var order = await Db.Orders.FindAsync(id);
        if (order == null) 
            return null;
        
        Db.Orders.Remove(order);
        await Db.SaveChangesAsync();
        return order;
    }

    public async Task<Order> Update(Order order)
    {
        Db.ChangeTracker.Clear();
        Db.Entry(order).State = EntityState.Modified;
        await Db.SaveChangesAsync();
        return order;
    }
}