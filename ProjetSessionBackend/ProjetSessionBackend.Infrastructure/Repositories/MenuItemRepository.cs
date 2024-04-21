using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjetSessionBackend.Core;
using ProjetSessionBackend.Core.Interfaces.Repositories;

namespace ProjetSessionBackend.Infrastructure.Repositories;

public class MenuItemRepository: BaseRepository, IMenuItemRepository
{
    public MenuItemRepository(IMapper mapper) : base(mapper)
    {
    }
    
    public List<MenuItem> GetAll()
    {
        return Db.MenuItems.ToList();
    }

    public MenuItem? GetById(int id)
    {
        return Db.MenuItems.FirstOrDefault(p => p.MenuItemId == id);
    }

    public void DeleteById(int id)
    {
        var menuItem = Db.MenuItems.Find(id);
        if (menuItem == null)
        {
            throw new ArgumentNullException(nameof(menuItem));
        }

        Db.MenuItems.Remove(menuItem);
        Db.SaveChanges();
    }
    public void insert(MenuItem menuItem)
    {
        if (menuItem == null)
        {
            throw new ArgumentNullException(nameof(menuItem));
        }
        Db.MenuItems.Add(menuItem);
        Db.SaveChanges();
    }

    public void update(MenuItem menuItem)
    {
        if (menuItem == null)
        {
            throw new ArgumentNullException(nameof(menuItem));
        }
        Db.ChangeTracker.Clear();
        Db.Entry(menuItem).State = EntityState.Modified;
        Db.SaveChanges();
    }
}