using ProjetSessionBackend.Core.Models.Entities;

namespace ProjetSessionBackend.Core.Interfaces.Repositories;

public interface IRestaurantRepository
{
    public Task<IEnumerable<Restaurant>> GetAll();
    public Task<Restaurant?> GetById(int id);
    public Task<Restaurant> Create(Restaurant restaurant);
    public Task<Restaurant?> Delete(int id);

    public Task<Restaurant> Update(Restaurant restaurant);
}