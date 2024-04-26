using AutoMapper;
using ProjetSessionBackend.Core.Database;
using ProjetSessionBackend.Core.Database.Models;
using ProjetSessionBackend.Core.Interfaces.Repositories;

namespace ProjetSessionBackend.Infrastructure.Repositories;

public class RoleRepository : BaseRepository, IRoleRepository
{
    public RoleRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper) { }

    public IEnumerable<Role> GetAll() => Db.Roles;
    public Role? GetById(int id) => Db.Roles.Find(id);
}