using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjetSessionBackend.Core.Interfaces.Repositories;
using ProjetSessionBackend.Core.Models.Entities;

namespace ProjetSessionBackend.Infrastructure.Repositories;

public class RoleRepository : BaseRepository, IRoleRepository
{
    public RoleRepository(ApplicationDbContext context) : base(context) { }

    public async Task<IEnumerable<Role>> GetAll() => await Db.Roles.ToListAsync();
    public async Task<Role?> GetById(int id) => await Db.Roles.FindAsync(id);
}