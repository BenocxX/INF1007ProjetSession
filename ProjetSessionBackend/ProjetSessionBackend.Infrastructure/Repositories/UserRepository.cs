using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using ProjetSessionBackend.Core.Interfaces.Repositories;
using ProjetSessionBackend.Core.Interfaces.Services;
using ProjetSessionBackend.Core.Models.Entities;

namespace ProjetSessionBackend.Infrastructure.Repositories;

public class UserBaseRepository : BaseRepository<User>, IUserRepository
{
    private readonly IHashService _hashService;
    
    public UserBaseRepository(
        ApplicationDbContext context, 
        IMapper mapper, 
        IHashService hashService) : base(context, mapper)
    {
        _hashService = hashService;
    }

    protected override IIncludableQueryable<User, Role> GetWithInclude() => Db.Users.Include(u => u.Role);

    public Task<User?> GetUserByEmail(string email) => Db.Users.FirstOrDefaultAsync(u => u.Email == email);

    public new async Task<User> Create(User entity)
    {
        entity.Password = _hashService.Hash(entity.Password);
        return await base.Create(entity);
    }
}