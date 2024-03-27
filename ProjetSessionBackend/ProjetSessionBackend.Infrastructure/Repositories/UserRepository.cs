using ProjetSessionBackend.Core.Interfaces.Repositories;
using ProjetSessionBackend.Core.Models.Entities;

namespace ProjetSessionBackend.Infrastructure.Repositories;

public class UserRepository : BaseRepository, IUserRepository
{
    public List<User> GetAll()
    {
        return Db.Users.ToList();
    }
}