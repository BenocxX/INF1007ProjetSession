using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjetSessionBackend.Core.Interfaces.Repositories;
using ProjetSessionBackend.Core.Models.Entities;

namespace ProjetSessionBackend.Infrastructure.Repositories;

public class MenuRepository : BaseRepository, IMenuRepository
{
    public MenuRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
    
    public async Task<IEnumerable<Menu>> GetAll()
    {
        return await Db.Menus.ToListAsync();
    }

    public async Task<Menu?> GetById(int id)
    {
        return await Db.Menus.FindAsync(id);
    }

    public async Task<Menu> Create(Menu menu)
    {
        await Db.Menus.AddAsync(menu);
        await Db.SaveChangesAsync();
        return menu;
    }

    public async Task<Menu?> CreateWithExistingMenuItems(Menu menu, List<int> ids)
    {
        var menuItems = await Db.MenuItems.Where(mi => ids.Contains(mi.MenuItemId)).ToListAsync();
        menu.MenuItems.AddRange(menuItems);

        var newMenu = await Db.Menus.AddAsync(menu);
        await Db.SaveChangesAsync();
        
        // Return the menu with the generated id and included MenuItems because
        // createdMenu doesn't have the MenuItems
        return await GetById(newMenu.Entity.MenuId);
    }

    public async Task<Menu?> Delete(int id)
    {
        var menu = await Db.Menus.FindAsync(id);
        if (menu == null) 
            return null;
        
        Db.Menus.Remove(menu);
        await Db.SaveChangesAsync();
        return menu;
    }

    public async Task<Menu> Update(Menu menu, List<int> ids)
    {
        var existingMenu = await Db.Menus
            .Include(m => m.MenuItems)
            .FirstOrDefaultAsync(m => m.MenuId == menu.MenuId);

        if (existingMenu == null)
        {
            return null;
        }

        existingMenu.MenuItems.Clear();

        var menuItemsToAdd = await Db.MenuItems
            .Where(mi => ids.Contains(mi.MenuItemId))
            .ToListAsync();

        foreach (var menuItem in menuItemsToAdd)
        {
            existingMenu.MenuItems.Add(menuItem);
        }

        existingMenu.Name = menu.Name;
        Db.Entry(existingMenu).State = EntityState.Modified;
        await Db.SaveChangesAsync();
        return existingMenu;;
    }
}