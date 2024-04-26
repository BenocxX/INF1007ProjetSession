using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjetSessionBackend.Core.Database;
using ProjetSessionBackend.Core.Database.Models;
using ProjetSessionBackend.Core.Interfaces.Repositories;

namespace ProjetSessionBackend.Infrastructure.Repositories;

public class UserRepository : BaseRepository, IUserRepository
{
    public UserRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper) {}

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

    public async Task<User> Create(User user)
    {
        var newUser = await Db.Users.AddAsync(user);
        await Db.SaveChangesAsync();
        return newUser.Entity;
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