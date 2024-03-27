using AutoMapper;
using ProjetSessionBackend.Core.Interfaces.Repositories;
using ProjetSessionBackend.Core.Models.DTOs;

namespace ProjetSessionBackend.Infrastructure.Repositories;

public class UserRepository : BaseRepository, IUserRepository
{
    public UserRepository(IMapper mapper) : base(mapper)
    {
    }
    
    public List<UserResponse> GetAll()
    {
        return Db.Users.Select(user => Mapper.Map<UserResponse>(user)).ToList();
    }
}