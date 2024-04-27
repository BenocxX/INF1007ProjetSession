using Microsoft.AspNetCore.Mvc;
using ProjetSessionBackend.Core.Interfaces.Repositories;
using ProjetSessionBackend.Core.Models.Entities;

namespace ProjetSessionBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        private readonly IMenuItemRepository _menuItemRepository;

        public MenuItemController(IMenuItemRepository menuItemRepository)
        {
            _menuItemRepository = menuItemRepository;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuItem>>> GetMenuItems()
        {
            var menuItems = await _menuItemRepository.GetAll();
            return Ok(menuItems);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<MenuItem>> GetMenuItem(int id)
        {
            var menuItem = await _menuItemRepository.GetById(id);
            return Ok(menuItem);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateMenuItem(MenuItem menuItem)
        {
            await _menuItemRepository.Create(menuItem);
            return Ok();
        }
        
        [HttpDelete]
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
