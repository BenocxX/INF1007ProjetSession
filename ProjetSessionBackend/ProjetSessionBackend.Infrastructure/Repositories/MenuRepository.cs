using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjetSessionBackend.Core;
using ProjetSessionBackend.Core.Interfaces.Repositories;
using ProjetSessionBackend.Core.Models.DTOs;
using ProjetSessionBackend.Core.Models.Entities;

namespace ProjetSessionBackend.Infrastructure.Repositories;

public class MenuRepository: BaseRepository, IMenuRepository
{
    public MenuRepository(IMapper mapper) : base(mapper)
    {
    }
    
    public List<Menu> GetAll()
    {
        return Db.Menus.ToList();
    }

    public Menu? GetById(int id)
    {
        return Db.Menus.Include(m => m.MenuItems).FirstOrDefault(m => m.MenuId == id);
    }

    public void DeleteById(int id)
    {
        var existingMenu = Db.Menus.FirstOrDefault(m => m.MenuId == id);
        
        if (existingMenu == null)
            throw new ArgumentNullException(nameof(id));

        Db.Menus.Remove(existingMenu);
        Db.SaveChanges();
    }

    public void insert(MenuResponse menu)
    {
        if (menu == null)
            throw new ArgumentNullException(nameof(menu));

        var menuItemMenus = CreateMenuItemMenus(menu);
        
        var newMenu = Db.Menus.Add(new Menu { Name = menu.Name });
        menuItemMenus.ForEach(m => newMenu.Entity.MenuItems.Add(m.MenuItem));
        
        Db.SaveChanges();
    }

    public void update(MenuResponse menu)
    {
        Db.ChangeTracker.Clear();
        Db.SaveChanges();
    }

    private List<MenuMenuItem> CreateMenuItemMenus(MenuResponse menu)
    {
        var menuItemMenus = new List<MenuMenuItem>();

        if (menu.MenuItems == null) 
            return menuItemMenus;
        
        foreach (var menuItem in menu.MenuItems)
        {
            var menuItemMenu = new MenuMenuItem { MenuItemId = menuItem.MenuItemId };
            menuItemMenus.Add(menuItemMenu);
        }

        return menuItemMenus;
    }
}