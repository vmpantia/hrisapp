using System.Linq.Expressions;
using HRIS.Infrastructure.Databases.Entities.Contracts;

namespace HRIS.Infrastructure.Databases.Repositories.Contracts;

public interface IBaseRepository<TEntity>
    where TEntity : BaseEntity
{
    IQueryable<TEntity> GetAll();
    IQueryable<TEntity> GetByExpression(Expression<Func<TEntity, bool>> expression);
    Task CreateAsync(TEntity entity, CancellationToken token = default);
    Task UpdateAsync(TEntity entity, CancellationToken token = default);
}