using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjetSessionBackend.Core.Interfaces.Repositories;
using ProjetSessionBackend.Core.Models.DTOs.User;
using ProjetSessionBackend.Core.Models.Entities;

namespace ProjetSessionBackend.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : BaseController
{
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;

    public UserController(
        IMapper mapper, 
        IUserRepository userRepository, 
        IRoleRepository roleRepository) : base(mapper)
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserResponse>>> GetUsers()
    {
        var users = await _userRepository.GetAll();
        return Ok(Mapper.Map<IEnumerable<UserResponse>>(users));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserResponse>> GetUser(int id)
    {
        var user = await _userRepository.GetById(id);

        if (user == null) 
            return NotFound();

        return Ok(Mapper.Map<UserResponse>(user));
    }

    [HttpPost]
    public async Task<ActionResult<UserResponse>> CreateUser(CreateUserRequest request)
    {
        var existingRole = await _roleRepository.GetById(request.RoleId);
        if (existingRole == null)
            return BadRequest("Role not found");
        
        var user = Mapper.Map<User>(request);
        var createdUser = await _userRepository.Create(user);
        
        var response = Mapper.Map<UserResponse>(createdUser);
        return CreatedAtAction(nameof(GetUser), new { id = user.UserId }, response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var user = await _userRepository.GetById(id);
        if (user == null) 
            return NotFound();

        await _userRepository.Delete(id);
        
        return NoContent();
    }
}