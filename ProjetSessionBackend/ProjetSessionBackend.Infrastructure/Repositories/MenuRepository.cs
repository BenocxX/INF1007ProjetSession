using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
        return Db.Menus.FirstOrDefault(p => p.id == id);
    }

    public void DeleteById(int id)
    {
        var menu = Db.Menus.Find(id);
        if (menu == null)
        {
            throw new ArgumentNullException(nameof(menu));
        }

        Db.Menus.Remove(menu);
        Db.SaveChanges();
    }

    public void insert(Menu menu)
    {
        if (menu == null)
        {
            throw new ArgumentNullException(nameof(menu));
        }
        Db.Menus.Add(menu);
        Db.SaveChanges();
    }

    public void update(Menu menu)
    {
        if (menu == null)
        {
            throw new ArgumentNullException(nameof(menu));
        }
        Console.WriteLine(menu);
        Db.Entry(menu).State = EntityState.Modified;
        Db.SaveChanges();
    }
}