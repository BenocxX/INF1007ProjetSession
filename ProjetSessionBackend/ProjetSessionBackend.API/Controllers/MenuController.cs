using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetSessionBackend.Core.Interfaces.Repositories;
using ProjetSessionBackend.Core.Models.DTOs.Menu;
using ProjetSessionBackend.Core.Models.Entities;

namespace ProjetSessionBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : BaseController
    {
        private readonly IMenuRepository _menuRepository;
        
        public MenuController(IMapper mapper, IMenuRepository menuRepository) : base(mapper)
        {
            _menuRepository = menuRepository;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Menu>>> GetMenus()
        {
            var menus = await _menuRepository.GetAll();
            return Ok(Mapper.Map<IEnumerable<MenuResponse>>(menus));
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Menu>> GetMenu(int id)
        {
            var menu = await _menuRepository.GetById(id);
            if (menu == null)
                return NotFound();
            
            return Ok(Mapper.Map<MenuResponse>(menu));
        }
        
        [HttpPost]
        [Authorize(Roles = "Employee,Admin")]
        public async Task<ActionResult<Menu>> Create(CreateMenuRequest request)
        {
            var menuToCreate = Mapper.Map<Menu>(request);
            var createdMenu = await _menuRepository.CreateWithExistingMenuItems(menuToCreate, request.MenuItemsId);
            
            if (createdMenu == null)
                return BadRequest();

            var response = Mapper.Map<MenuResponse>(createdMenu);
            return CreatedAtAction(nameof(GetMenu), new { id = createdMenu.MenuId }, response);
        }
        
        [HttpDelete("{id}")]
        [Authorize(Roles = "Employee,Admin")]
        public async Task<ActionResult> Delete(int id)
        {
            var menu = await _menuRepository.Delete(id);
            if (menu == null)
                return NotFound();
            
            return NoContent();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Employee,Admin")]
        public async Task<ActionResult<Menu>> Update(int id, CreateMenuRequest request)
        {
            var existingMenu = await _menuRepository.GetById(id);
            if (existingMenu == null)
                return BadRequest("Menu not found");
            
            var menu = Mapper.Map<Menu>(request);
            menu.MenuId = existingMenu.MenuId;
            
            var updatedMenu = await _menuRepository.Update(menu, request.MenuItemsId);
            var response = Mapper.Map<MenuResponse>(updatedMenu);
            return CreatedAtAction(nameof(GetMenu), new { id = updatedMenu.MenuId }, response);
        }
    }
}
