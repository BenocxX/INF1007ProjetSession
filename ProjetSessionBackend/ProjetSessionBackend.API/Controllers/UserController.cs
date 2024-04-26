using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjetSessionBackend.Core.Database.Models;
using ProjetSessionBackend.Core.DTOs.User;
using ProjetSessionBackend.Core.Interfaces.Repositories;

namespace ProjetSessionBackend.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;

    public UserController(
        IMapper mapper, 
        IUserRepository userRepository, 
        IRoleRepository roleRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _roleRepository = roleRepository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<UserResponse>> GetUsers()
    {
        var users = _userRepository.GetAll();
        return Ok(_mapper.Map<IEnumerable<UserResponse>>(users));
    }

    [HttpGet("{id}")]
    public ActionResult<UserResponse> GetUser(int id)
    {
        var user = _userRepository.GetById(id);

        if (user == null) 
            return NotFound();

        return Ok(_mapper.Map<UserResponse>(user));
    }

    [HttpPost]
    public ActionResult<UserResponse> PostUser(CreateUserRequest createUserRequest)
    {
        var existingRole = _roleRepository.GetById(createUserRequest.RoleId);
        if (existingRole == null)
            return BadRequest("Role not found");
        
        var user = _mapper.Map<User>(createUserRequest);
        
        var createdUser = _userRepository.Create(user);
        
        var response = _mapper.Map<UserResponse>(createdUser);
        return CreatedAtAction("GetUser", new { id = user.UserId }, response);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        var user = _userRepository.GetById(id);
        if (user == null) 
            return NotFound();

        _userRepository.Delete(id);
        
        return NoContent();
    }
}