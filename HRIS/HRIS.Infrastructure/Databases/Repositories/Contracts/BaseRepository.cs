using System.Linq.Expressions;
using HRIS.Infrastructure.Databases.Contexts;
using HRIS.Infrastructure.Databases.Entities.Contracts;
using Microsoft.EntityFrameworkCore;

namespace HRIS.Infrastructure.Databases.Repositories.Contracts;

public class BaseRepository<TEntity> : IBaseRepository<TEntity>
    where TEntity : BaseEntity
{
    private readonly HRISDbContext _context;
    private readonly DbSet<TEntity> _table;

    protected BaseRepository(HRISDbContext context)
    {
        _context = context;
        _table = context.Set<TEntity>();
    }
    
    public IQueryable<TEntity> GetAll() => _table;
    
    public IQueryable<TEntity> GetByExpression(Expression<Func<TEntity, bool>> expression) => _table.Where(expression);
    
    public async Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default) =>
        await _table.AnyAsync(expression, cancellationToken);

    public async Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        var result = await _table.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        
        return result.Entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        var result = _table.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);
        
        return result.Entity;
    }

    public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        _table.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }
}