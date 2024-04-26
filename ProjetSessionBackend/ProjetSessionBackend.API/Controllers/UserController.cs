using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetSessionBackend.Core.Database;
using ProjetSessionBackend.Core.Database.Models;
using ProjetSessionBackend.Core.DTOs.User;

namespace ProjetSessionBackend.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;

    public UserController(IMapper mapper, ApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    // GET: api/User
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserResponse>>> GetUsers()
    {
        var users = await _context.Users
            .Include(u => u.Role)
            .ToListAsync();

        return Ok(_mapper.Map<IEnumerable<UserResponse>>(users));
    }

    // GET: api/User/5
    [HttpGet("{id}")]
    public async Task<ActionResult<UserResponse>> GetUser(int id)
    {
        var user = await _context.Users
            .Include(u => u.Role)
            .FirstOrDefaultAsync(u => u.UserId == id);

        if (user == null) 
            return NotFound();

        return _mapper.Map<UserResponse>(user);
    }

    // POST: api/User
    [HttpPost]
    public async Task<ActionResult<UserResponse>> PostUser(CreateUserRequest createUserRequest)
    {
        var existingRole = await _context.Roles.FindAsync(createUserRequest.RoleId);
        if (existingRole == null)
            return BadRequest("Role not found");
        
        var user = _mapper.Map<User>(createUserRequest);
        
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        
        var userResponse = _mapper.Map<UserResponse>(user);
        return CreatedAtAction("GetUser", new { id = user.UserId }, userResponse);
    }

    // DELETE: api/User/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var user = await _context.Users.FindAsync(id);
        
        if (user == null) 
            return NotFound();

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}