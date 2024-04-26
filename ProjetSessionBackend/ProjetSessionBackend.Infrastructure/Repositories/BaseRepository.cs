using AutoMapper;
using ProjetSessionBackend.Core.Database;

namespace ProjetSessionBackend.Infrastructure.Repositories;

public abstract class BaseRepository
{
    protected readonly ApplicationDbContext Db;
    protected readonly IMapper Mapper;

    protected BaseRepository(ApplicationDbContext context, IMapper mapper)
    {
        Db = context;
        Mapper = mapper;
    } 
}