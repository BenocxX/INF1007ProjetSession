using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjetSessionBackend.Core.Database;
using ProjetSessionBackend.Core.Database.Models;
using ProjetSessionBackend.Core.Interfaces.Repositories;

namespace ProjetSessionBackend.Infrastructure.Repositories;

public class UserRepository : BaseRepository, IUserRepository
{
    public UserRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper) {}
    
    public IEnumerable<User> GetAll() => Db.Users.Include(u => u.Role);

    public User? GetById(int id)
    {
        return Db.Users
            .Include(u => u.Role)
            .FirstOrDefault(u => u.UserId == id);
    }

    public User Create(User user)
    {
        var newUser = Db.Users.Add(user);
        Db.SaveChanges();
        return newUser.Entity;
    }

    public User? Delete(int id)
    {
        var user = Db.Users.Find(id);
        if (user == null)
            return null;
        
        Db.Users.Remove(user);
        Db.SaveChanges();
        return user;
    }
}