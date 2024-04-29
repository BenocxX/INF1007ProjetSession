using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjetSessionBackend.Core.Interfaces.Repositories;
using ProjetSessionBackend.Core.Models.Entities;

namespace ProjetSessionBackend.Infrastructure.Repositories;

public class RestaurantRepository : BaseRepository, IRestaurantRepository
{
    public RestaurantRepository(ApplicationDbContext context) : base(context) { }

    public async Task<IEnumerable<Restaurant>> GetAll()
    {
        return await Db.Restaurants.ToListAsync();
    }

    public async Task<Restaurant?> GetById(int id)
    {
        return await Db.Restaurants.FindAsync(id);
    }

    public async Task<Restaurant> Create(Restaurant restaurant)
    {
        var newRestaurant = await Db.Restaurants.AddAsync(restaurant);
        await Db.SaveChangesAsync();
        return newRestaurant.Entity;
    }

    public async Task<Restaurant?> Delete(int id)
    {
        var restaurant = await Db.Restaurants.FindAsync(id);
        if (restaurant == null)
            return null;

        Db.Restaurants.Remove(restaurant);
        await Db.SaveChangesAsync();

        return restaurant;
    }
}