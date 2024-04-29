using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjetSessionBackend.Core.Interfaces.Repositories;
using ProjetSessionBackend.Core.Models.Entities;

namespace ProjetSessionBackend.Infrastructure.Repositories;

public class MenuItemRepository : BaseRepository, IMenuItemRepository
{
    public MenuItemRepository(ApplicationDbContext context) : base(context) { }

    public async Task<IEnumerable<MenuItem>> GetAll()
    {
        return await Db.MenuItems.ToListAsync();
    }

    public async Task<MenuItem?> GetById(int id)
    {
        return await Db.MenuItems.FindAsync(id);
    }

    public async Task<MenuItem> Create(MenuItem menuItem)
    {
        var newMenu = await Db.MenuItems.AddAsync(menuItem);
        await Db.SaveChangesAsync();
        return newMenu.Entity;
    }

    public async Task<MenuItem?> Delete(int id)
    {
        var menuItem = await Db.MenuItems.FindAsync(id);
        if (menuItem == null) 
            return null;
        
        Db.MenuItems.Remove(menuItem);
        await Db.SaveChangesAsync();
        return menuItem;
    }

    public async Task<MenuItem> Update(MenuItem menuItem)
    {
        Db.ChangeTracker.Clear();
        Db.Entry(menuItem).State = EntityState.Modified;
        await Db.SaveChangesAsync();
        return menuItem;
    }
}