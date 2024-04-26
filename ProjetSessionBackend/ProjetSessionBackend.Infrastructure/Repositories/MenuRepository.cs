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

    public void insert(MenuResponse menuResponse)
    {
        if (menuResponse.MenuItems == null)
            throw new ArgumentNullException(nameof(menuResponse));
        
        var menu = new Menu { Name = menuResponse.Name };
        var newMenu = Db.Menus.Add(menu);
        Db.SaveChanges();
        
        Db.Menus.Attach(newMenu.Entity);
        
        foreach (var menuResponseMenuItem in menuResponse.MenuItems)
            newMenu.Entity.MenuItems.Add(menuResponseMenuItem);
        
        Db.SaveChanges();
    }

    public void update(MenuResponse menu)
    {
        Db.ChangeTracker.Clear();
        Db.SaveChanges();
    }
}