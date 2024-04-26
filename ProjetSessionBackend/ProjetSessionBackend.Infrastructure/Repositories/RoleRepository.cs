using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjetSessionBackend.Core.Database;
using ProjetSessionBackend.Core.Database.Models;
using ProjetSessionBackend.Core.Interfaces.Repositories;

namespace ProjetSessionBackend.Infrastructure.Repositories;

public class RoleRepository : BaseRepository, IRoleRepository
{
    public RoleRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper) { }

    public async Task<IEnumerable<Role>> GetAll() => await Db.Roles.ToListAsync();
    public async Task<Role?> GetById(int id) => await Db.Roles.FindAsync(id);
}