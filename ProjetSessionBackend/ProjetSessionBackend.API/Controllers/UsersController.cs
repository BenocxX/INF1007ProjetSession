using Microsoft.AspNetCore.Mvc;
using ProjetSessionBackend.Core.Interfaces.Repositories;
using ProjetSessionBackend.Core.Models.DTOs;

namespace ProjetSessionBackend.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUsersRepository _repository;
    
    public UsersController(IUsersRepository repository)
    {
        _repository = repository;
    }
    
    [HttpGet]
    public ActionResult<List<UserResponse>> GetAll()
    {
        return Ok(_repository.GetAll());
    }
}