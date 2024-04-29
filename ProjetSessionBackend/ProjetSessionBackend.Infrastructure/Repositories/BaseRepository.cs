using AutoMapper;
using ProjetSessionBackend.Core.Models.Entities;

namespace ProjetSessionBackend.Infrastructure.Repositories;

public abstract class BaseRepository
{
    protected readonly ApplicationDbContext Db;

    protected BaseRepository(ApplicationDbContext context)
    {
        Db = context;
    } 
}