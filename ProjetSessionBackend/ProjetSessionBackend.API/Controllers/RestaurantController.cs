using Microsoft.AspNetCore.Mvc;
using ProjetSessionBackend.Core;
using ProjetSessionBackend.Core.Interfaces.Repositories;
using ProjetSessionBackend.Core.Models.Entities;

namespace ProjetSessionBackend.API.Controllers;


[ApiController]
[Route("[controller]")]
public class RestaurantController: ControllerBase
{
    private readonly IRestaurantRepository _restaurantRepository;

    public RestaurantController(IRestaurantRepository _restaurantRepository)
    {
        this._restaurantRepository = _restaurantRepository;
    }

    [HttpGet]
    public ActionResult<List<Restaurant>> GetAll()
    {
        return Ok(_restaurantRepository.GetAll());
    }
    
    [HttpGet("{id}")]
    public IActionResult GetRestaurantById(int id)
    {
        var restaurant = _restaurantRepository.GetById(id);
        if (restaurant == null)
        {
            return NotFound();
        }
        return Ok(restaurant);
    }
    
    [HttpPost]
    public IActionResult Store([FromBody] Restaurant restaurant)
    {
        if (restaurant == null)
        {
            return BadRequest();
        }
        _restaurantRepository.insert(restaurant);
        return CreatedAtAction(nameof(GetRestaurantById), new { id = restaurant.RestaurantId }, restaurant);
    }
    
    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Restaurant restaurant)
    {
        if (restaurant == null)
        {
            return BadRequest();
        }
        var existingRestaurant = _restaurantRepository.GetById(id);
        if (existingRestaurant == null)
        {
            return NotFound();
        }

        restaurant.RestaurantId = existingRestaurant.RestaurantId;
        _restaurantRepository.update(restaurant);
        return NoContent();
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var existingRestaurant = _restaurantRepository.GetById(id);
        if (existingRestaurant == null)
        {
            return NotFound();
        }
        _restaurantRepository.DeleteById(id);
        return NoContent();
    }
}