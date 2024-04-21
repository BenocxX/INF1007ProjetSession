// using ProjetSessionBackend.Core.Models.Entities;

namespace ProjetSessionBackend.Core.Interfaces.Repositories;

public interface IRestaurantRepository
{
    List<Restaurant> GetAll();
    
    Restaurant GetById(int id);
    
    void DeleteById(int id);

    void insert(Restaurant restaurant);

    void update(Restaurant restaurant);
}