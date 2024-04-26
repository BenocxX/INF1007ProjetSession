using AutoMapper;
using ProjetSessionBackend.Core.Database;
using ProjetSessionBackend.Core.DTOs.User;

namespace ProjetSessionBackend.Infrastructure.Repositories;

public class UserRepository : BaseRepository
{
    public UserRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper) {}
    
    // public List<UserResponse>
}