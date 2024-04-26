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
    private readonly ApplicationDbContext _context;

    public UserController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/User
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        return await _context.Users
            .Include(u => u.Role)
            .ToListAsync();
    }

    // GET: api/User/5
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        var user = await _context.Users
            .Include(u => u.Role)
            .FirstOrDefaultAsync(u => u.UserId == id);

        if (user == null) 
            return NotFound();

        return user;
    }

    // POST: api/User
    [HttpPost]
    public async Task<ActionResult<User>> PostUser(CreateUserRequest createUserRequest)
    {
        var existingRole = await _context.Roles.FindAsync(createUserRequest.RoleId);
        if (existingRole == null)
            return BadRequest("Role not found");
        
        // TODO: Use AutoMapper
        var user = new User
        {
            Firstname = createUserRequest.Firstname,
            Lastname = createUserRequest.Lastname,
            Email = createUserRequest.Email,
            Phone = createUserRequest.Phone,
            RoleId = createUserRequest.RoleId
        };
        
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetUser", new { id = user.UserId }, user);
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