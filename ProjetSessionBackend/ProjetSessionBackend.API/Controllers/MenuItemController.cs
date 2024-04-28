using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetSessionBackend.Core.Interfaces.Repositories;
using ProjetSessionBackend.Core.Models.DTOs.MenuItem;
using ProjetSessionBackend.Core.Models.Entities;

namespace ProjetSessionBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : BaseController
    {
        private readonly IMenuItemRepository _menuItemRepository;

        public MenuItemController(IMapper mapper, IMenuItemRepository menuItemRepository) 
            : base(mapper)
        {
            _menuItemRepository = menuItemRepository;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuItemResponse>>> GetMenuItems()
        {
            var menuItems = await _menuItemRepository.GetAll();
            return Ok(Mapper.Map<IEnumerable<MenuItemResponse>>(menuItems));
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<MenuItemResponse>> GetMenuItem(int id)
        {
            var menuItem = await _menuItemRepository.GetById(id);
            return Ok(Mapper.Map<MenuItemResponse>(menuItem));
        }
        
        [HttpPost]
        [Authorize(Roles = "Employee,Admin")]
        public async Task<ActionResult<MenuItemResponse>> CreateMenuItem(CreateMenuItemRequest request)
        {
            var menuItem = Mapper.Map<MenuItem>(request);
            await _menuItemRepository.Create(menuItem);
            var response = Mapper.Map<MenuItemResponse>(menuItem);
            return CreatedAtAction(nameof(GetMenuItem), new { id = menuItem.MenuItemId }, response);
        }
        
        [HttpDelete("{id}")]
        [Authorize(Roles = "Employee,Admin")]
        public async Task<IActionResult> DeleteMenuItem(int id)
        {
            var menuItem = await _menuItemRepository.GetById(id);
            if (menuItem == null) 
                return NotFound();
            
            await _menuItemRepository.Delete(id);
            
            return Ok();
        }
    }
}
