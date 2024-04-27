using ProjetSessionBackend.Core.Models.Entities;

namespace ProjetSessionBackend.Core.Interfaces.Repositories;

public interface IReadOnlyEntityRepository<TEntity> where TEntity : BaseEntity
{
    public Task<IEnumerable<TEntity>> GetAll();
    public Task<TEntity?> GetById(int id);
}

public interface IEntityRepository<TEntity> : IReadOnlyEntityRepository<TEntity> 
    where TEntity : BaseEntity
{
    public Task<TEntity> Create(TEntity entity);
    public Task<TEntity?> Delete(int id);
}