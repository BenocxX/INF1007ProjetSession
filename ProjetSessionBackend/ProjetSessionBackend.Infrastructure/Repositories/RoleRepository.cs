using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using ProjetSessionBackend.Core.Interfaces.Repositories;
using ProjetSessionBackend.Core.Models.Entities;

namespace ProjetSessionBackend.Infrastructure.Repositories;

public class RoleBaseRepository : BaseRepository<Role>, IRoleRepository
{
    public RoleBaseRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper) { }
    
    protected override IIncludableQueryable<Role, Role> GetWithInclude() => Db.Roles.Include(r => r);
}