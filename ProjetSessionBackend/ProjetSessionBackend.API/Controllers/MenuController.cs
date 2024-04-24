using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using ProjetSessionBackend.Core;
using ProjetSessionBackend.Core.Interfaces.Repositories;
using ProjetSessionBackend.Core.Models.DTOs;
using ProjetSessionBackend.Core.Models.Entities;

namespace ProjetSessionBackend.API.Controllers;

[ApiController]
[Route("[controller]")]
public class MenuController: ControllerBase
{
    private readonly IMenuRepository _menuRepository;

    public MenuController(IMenuRepository _menuRepository)
    {
        this._menuRepository = _menuRepository;
    }

    [HttpGet]
    public ActionResult<List<Menu>> GetAll()
    {
        return Ok(_menuRepository.GetAll());
    }
    
    [HttpGet("{id}")]
    public ActionResult<string> GetMenuById(int id)
    {
        var menu = _menuRepository.GetById(id);
        if (menu == null)
        {
            return NotFound();
        }

        string json = JsonSerializer.Serialize(menu, new JsonSerializerOptions
        {
            WriteIndented = true,
            ReferenceHandler = ReferenceHandler.IgnoreCycles
        });

        return Ok(json);
    }
    
    [HttpPost]
    public ActionResult<MenuResponse> Store([FromBody] MenuResponse menu)
    {
        if (menu == null)
        {
            return BadRequest();
        }
        _menuRepository.insert(menu);
        return CreatedAtAction(nameof(GetMenuById), new { id = menu.MenuId }, menu);
    }

    [HttpPut("{id}")]
    public ActionResult<MenuResponse> Update(int id, [FromBody] MenuResponse menu)
    {
        if (id == null)
        {
            return BadRequest();
        }
        var existingMenu = _menuRepository.GetById(id);
        if (existingMenu == null)
        {
            return NotFound();
        }

        menu.MenuId = id;
        _menuRepository.update(menu);
        return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var existingMenu = _menuRepository.GetById(id);
        if (existingMenu == null)
        {
            return NotFound();
        }
        _menuRepository.DeleteById(id);
        return NoContent();
    }
}