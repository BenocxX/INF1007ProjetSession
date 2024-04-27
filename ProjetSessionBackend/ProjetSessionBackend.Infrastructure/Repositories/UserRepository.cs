using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjetSessionBackend.Core.Database;
using ProjetSessionBackend.Core.Database.Models;
using ProjetSessionBackend.Core.Interfaces.Repositories;
using ProjetSessionBackend.Core.Interfaces.Services;

namespace ProjetSessionBackend.Infrastructure.Repositories;

public class UserRepository : BaseRepository, IUserRepository
{
    private readonly IHashService _hashService;
    
    public UserRepository(
        ApplicationDbContext context, 
        IMapper mapper, 
        IHashService hashService) : base(context, mapper)
    {
        _hashService = hashService;
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        return await Db.Users.Include(u => u.Role).ToListAsync();
    }

    public async Task<User?> GetById(int id)
    {
        return await Db.Users
            .Include(u => u.Role)
            .FirstOrDefaultAsync(u => u.UserId == id);
    }

    public Task<User?> GetUserByEmail(string email)
    {
        return Db.Users
            .Include(u => u.Role)
            .FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User> Create(User user)
    {
        user.Password = _hashService.Hash(user.Password);
        var newUser = await Db.Users.AddAsync(user);
        await Db.SaveChangesAsync();
        
        return await Db.Users
            .Include(u => u.Role)
            .FirstAsync(u => u.UserId == newUser.Entity.UserId);
    }

    public async Task<User?> Delete(int id)
    {
        var user = await Db.Users.FindAsync(id);
        if (user == null)
            return null;
        
        Db.Users.Remove(user);
        await Db.SaveChangesAsync();
        
        return user;
    }
}