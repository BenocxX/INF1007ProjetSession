using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetSessionBackend.Core.Interfaces.Repositories;
using ProjetSessionBackend.Core.Models.DTOs.Restaurant;
using ProjetSessionBackend.Core.Models.Entities;

namespace ProjetSessionBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : BaseController
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IMenuRepository _menuRepository;
        
        public RestaurantController(IMapper mapper, IRestaurantRepository restaurantRepository, IMenuRepository menuRepository) 
            : base(mapper)
        {
            _restaurantRepository = restaurantRepository;
            _menuRepository = menuRepository;
        }
        
        [HttpGet]
        [Authorize(Roles = "Client,Employee,Admin")]
        public async Task<ActionResult<IEnumerable<RestaurantResponse>>> GetRestaurants()
        {
            var restaurants = await _restaurantRepository.GetAll();
            return Ok(Mapper.Map<IEnumerable<RestaurantResponse>>(restaurants));
        }
        
        [HttpGet("{id}")]
        [Authorize(Roles = "Client,Employee,Admin")]
        public async Task<ActionResult<RestaurantResponse>> GetRestaurant(int id)
        {
            var restaurant = await _restaurantRepository.GetById(id);
            if (restaurant == null)
                return NotFound();
            
            return Ok(Mapper.Map<RestaurantResponse>(restaurant));
        }
        
        [HttpPost]
        [Authorize(Roles = "Employee,Admin")]
        public async Task<ActionResult<RestaurantResponse>> CreateRestaurant(CreateRestaurantRequest request)
        {
            var existingMenu = await _menuRepository.GetById(request.MenuId);
            if (existingMenu == null)
                return BadRequest("Menu not found");
            
            var restaurant = Mapper.Map<Restaurant>(request);
            var createdRestaurant = await _restaurantRepository.Create(restaurant);
            
            var response = Mapper.Map<RestaurantResponse>(createdRestaurant);
            return CreatedAtAction(nameof(GetRestaurant), new { id = createdRestaurant.RestaurantId }, response);
        }
        
        [HttpDelete("{id}")]
        [Authorize(Roles = "Employee,Admin")]
        public async Task<IActionResult> DeleteRestaurant(int id)
        {
            var restaurant = await _restaurantRepository.GetById(id);
            if (restaurant == null)
                return NotFound();
            
            await _restaurantRepository.Delete(id);
            return NoContent();
        }
    }
}
