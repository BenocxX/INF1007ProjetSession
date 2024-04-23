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

    public Menu GetById(int id)
    {
        var menu = Db.Menus.Include(m => m.MenuItems)
            .ThenInclude(mm => mm.MenuItem)
            .FirstOrDefault(m => m.MenuId == id);
        return menu;
    }

    public void DeleteById(int id)
    {
        var existingMenu = Db.Menus.FirstOrDefault(m => m.MenuId == id);
        
        if (existingMenu == null)
        {
            throw new ArgumentNullException(nameof(id));
        }

        Db.Menus.Remove(existingMenu);
        Db.SaveChanges();
    }

    public void insert(MenuResponse menu)
    {
        if (menu == null)
        {
            throw new ArgumentNullException(nameof(menu));
        }

        var _menuItemMenus = CreateMenuItemMenus(menu);
        
        Db.Menus.Add(new Menu
        {
            Name = menu.Name,
            MenuItems = _menuItemMenus.Any() ? _menuItemMenus : null        
        });
        Db.SaveChanges();
    }

    public void update(MenuResponse menu)
    {
        
        
        Db.ChangeTracker.Clear();
        Db.SaveChanges();
    }

    private List<MenuMenuItem> CreateMenuItemMenus(MenuResponse menu)
    {
        List<MenuMenuItem> _menuItemMenus = new List<MenuMenuItem>();
        
        if (menu.MenuItems != null)
        {
            foreach (var menuItem in menu.MenuItems)
            {
                _menuItemMenus.Add(new MenuMenuItem { MenuItemId = menuItem.MenuItemId });
            }
        }

        return _menuItemMenus;
    }
}