using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using ProjetSessionBackend.Core.Interfaces.Repositories;
using ProjetSessionBackend.Core.Models.Entities;

namespace ProjetSessionBackend.Infrastructure.Repositories;

public abstract class ReadOnlyBaseRepository<TEntity> : IReadOnlyEntityRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly ApplicationDbContext Db;
    protected readonly IMapper Mapper;
    
    protected ReadOnlyBaseRepository(ApplicationDbContext context, IMapper mapper)
    {
        Db = context;
        Mapper = mapper;
    }
    
    public async Task<IEnumerable<TEntity>> GetAll() => await GetWithInclude().ToListAsync();

    public async Task<TEntity?> GetById(int id) =>
        await GetWithInclude().FirstOrDefaultAsync(entity => entity.Id == id);

    protected abstract IIncludableQueryable<TEntity, object> GetWithInclude();
}

public abstract class BaseRepository<TEntity> : ReadOnlyBaseRepository<TEntity>, IEntityRepository<TEntity> where TEntity : BaseEntity
{
    protected BaseRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<TEntity> Create(TEntity entity)
    {
        var createdEntity = await Db.Set<TEntity>().AddAsync(entity);
        await Db.SaveChangesAsync();

        return (await GetById(createdEntity.Entity.Id))!;
    }

    public async Task<TEntity?> Delete(int id)
    {
        var entity = await GetWithInclude().FirstOrDefaultAsync(entity => entity.Id == id);
        if (entity == null)
            return null;
        
        Db.Set<TEntity>().Remove(entity);
        await Db.SaveChangesAsync();
        
        return entity;
    }
}