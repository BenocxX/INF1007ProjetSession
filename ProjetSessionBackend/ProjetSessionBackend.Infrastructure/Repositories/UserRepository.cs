using ProjetSessionBackend.Infrastructure.Entities;

namespace ProjetSessionBackend.Infrastructure.Repositories;

public class UserRepository : BaseRepository
{
    public List<User> GetAll()
    {
        return Db.Users.ToList();
    }
}