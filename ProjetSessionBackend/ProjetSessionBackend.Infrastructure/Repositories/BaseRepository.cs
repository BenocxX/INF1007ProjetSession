using AutoMapper;
using ProjetSessionBackend.Core;

namespace ProjetSessionBackend.Infrastructure.Repositories;

public abstract class BaseRepository
{
    protected readonly DatabaseContext Db;
    protected readonly IMapper Mapper;

    protected BaseRepository(IMapper mapper)
    {
        Db = new DatabaseContext();
        Mapper = mapper;
    } 
}