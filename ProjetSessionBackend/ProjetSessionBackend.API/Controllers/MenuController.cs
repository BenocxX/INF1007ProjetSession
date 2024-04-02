using Microsoft.AspNetCore.Mvc;
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
    public ActionResult<List<MenuResponse>> GetAll()
    {
        return Ok(_menuRepository.GetAll());
    }
    
    [HttpGet("{id}")]
    public ActionResult GetProductById(int id)
    {
        var menu = _menuRepository.GetById(id);
        if (menu == null)
        {
            return NotFound();
        }
        return Ok(menu);
    }
    
    [HttpPost]
    [Route("[controller]")]
    public ActionResult<MenuResponse> Store([FromBody] Menu menu)
    {
        if (menu == null)
        {
            return BadRequest();
        }
        _menuRepository.insert(menu);
        return CreatedAtAction(nameof(GetProductById), new { id = menu.id }, menu);
    }

    [HttpPut("{id}")]
    public ActionResult<MenuResponse> Update(int id, [FromBody] Menu menu)
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