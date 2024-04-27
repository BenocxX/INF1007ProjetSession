using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjetSessionBackend.Core.Interfaces.Repositories;
using ProjetSessionBackend.Core.Interfaces.Services;
using ProjetSessionBackend.Core.Models.Entities;

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
        return await Db.Users.ToListAsync();
    }

    public async Task<User?> GetById(int id)
    {
        return await Db.Users
            .Include(u => u.Role)
            .FirstOrDefaultAsync(u => u.UserId == id);
    }

    public Task<User?> GetUserByEmail(string email)
    {
        return Db.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User> Create(User user)
    {
        user.Password = _hashService.Hash(user.Password);
        var newUser = await Db.Users.AddAsync(user);
        await Db.SaveChangesAsync();
        
        // Return the user with the generated id and included Role because
        // newUser doesn't have the Role
        return (await GetById(newUser.Entity.UserId))!;
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