using Microsoft.AspNetCore.Mvc;
using ProjetSessionBackend.Core;
using ProjetSessionBackend.Core.Interfaces.Repositories;
using ProjetSessionBackend.Core.Models.DTOs;
using ProjetSessionBackend.Core.Models.Entities;

namespace ProjetSessionBackend.API.Controllers;

[ApiController]
[Route("[controller]")]
public class MenuItemController: ControllerBase
{
    private readonly IMenuItemRepository _menuItemRepository;

    public MenuItemController(IMenuItemRepository _menuItemRepository)
    {
        this._menuItemRepository = _menuItemRepository;
    }

    [HttpGet]
    public ActionResult<List<MenuItem>> GetAll()
    {
        return Ok(_menuItemRepository.GetAll());
    }
    
    [HttpGet("{id}")]
    public ActionResult GetMenuItemById(int id)
    {
        var menuItem = _menuItemRepository.GetById(id);
        if (menuItem == null)
        {
            return NotFound();
        }
        return Ok(menuItem);
    }
    
    [HttpPost]
    public ActionResult<MenuResponse> Store([FromBody] MenuItem menuItem)
    {
        if (menuItem == null)
        {
            return BadRequest();
        }
        _menuItemRepository.insert(menuItem);
        return Ok(menuItem);
    }

    [HttpPut("{id}")]
    public ActionResult<MenuResponse> Update(int id, [FromBody] MenuItem menuItem)
    {
        if (menuItem == null || id != menuItem.MenuItemId)
        {
            return BadRequest();
        }
        var existingMenuItem = _menuItemRepository.GetById(id);
        if (existingMenuItem == null)
        {
            return NotFound();
        }
        _menuItemRepository.update(menuItem);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var existingMenuItem = _menuItemRepository.GetById(id);
        if (existingMenuItem == null)
        {
            return NotFound();
        }
        _menuItemRepository.DeleteById(id);
        return NoContent();
    }
}