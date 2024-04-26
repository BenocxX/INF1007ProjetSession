using AutoMapper;
using ProjetSessionBackend.Core.Interfaces.Repositories;
using ProjetSessionBackend.Core.Models;
using ProjetSessionBackend.Core.Models.DTOs;

namespace ProjetSessionBackend.Infrastructure.Repositories;

public class UsersRepository : BaseRepository, IUsersRepository
{
    public UsersRepository(IMapper mapper) : base(mapper) { }
    
    public List<UserResponse> GetAll() => Db.Users.Select(user => Mapper.Map<UserResponse>(user)).ToList();
    public bool HasEmployee() => Db.Users.Any(user => user.RoleId == (int) ERole.Employee);
    public bool HasAdmin() => Db.Users.Any(user => user.RoleId == (int) ERole.Admin);
}