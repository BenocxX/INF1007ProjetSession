using ProjetSessionBackend.Infrastructure.Entities;

namespace ProjetSessionBackend.Infrastructure.Repositories;

public class BaseRepository
{
    protected readonly DatabaseContext Db;

    protected BaseRepository()
    {
        Db = new DatabaseContext();
    } 
}