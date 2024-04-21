using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjetSessionBackend.Core;
using ProjetSessionBackend.Core.Interfaces.Repositories;

namespace ProjetSessionBackend.Infrastructure.Repositories;

public class RestaurantRepository: BaseRepository, IRestaurantRepository
{
    public RestaurantRepository(IMapper mapper) : base(mapper)
    {
    }

    public List<Restaurant> GetAll()
    {
        return  Db.Restaurants.ToList();
    }

    public Restaurant GetById(int id)
    {
        return Db.Restaurants.FirstOrDefault(p => p.RestaurantId == id);
    }

    public void DeleteById(int id)
    {
        var restaurant = Db.Restaurants.Find(id);
        if (restaurant == null)
        {
            throw new ArgumentNullException(nameof(restaurant));
        }

        Db.Restaurants.Remove(restaurant);
        Db.SaveChanges();
    }

    public void insert(Restaurant restaurant)
    {
        if (restaurant == null)
        {
            throw new ArgumentNullException(nameof(restaurant));
        }

        Db.Restaurants.Add(restaurant);
        Db.SaveChanges();
    }

    public void update(Restaurant restaurant)
    {
        if (restaurant == null)
        {
            throw new ArgumentNullException(nameof(restaurant));
        }
        Db.ChangeTracker.Clear();
        Db.Entry(restaurant).State = EntityState.Modified;
        Db.SaveChanges();
    }
}