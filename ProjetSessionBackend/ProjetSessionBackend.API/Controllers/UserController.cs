using Microsoft.AspNetCore.Mvc;
using ProjetSessionBackend.Core.Interfaces.Repositories;
using ProjetSessionBackend.Core.Models.Entities;

namespace ProjetSessionBackend.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _repository;
    
    public UserController(IUserRepository repository)
    {
        _repository = repository;
    }
    
    [HttpGet]
    public ActionResult<List<User>> GetAll()
    {
        return Ok(_repository.GetAll());
    }
}