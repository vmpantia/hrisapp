using System.Linq.Expressions;
using HRIS.Infrastructure.Databases.Contexts;
using HRIS.Infrastructure.Databases.Entities.Contracts;
using Microsoft.EntityFrameworkCore;

namespace HRIS.Infrastructure.Databases.Repositories.Contracts;

public class BaseRepository<TEntity>
    where TEntity : BaseEntity
{
    private readonly HRISDbContext _context;
    private readonly DbSet<TEntity> _table;

    public BaseRepository(HRISDbContext context)
    {
        _context = context;
        _table = context.Set<TEntity>();
    }
    
    public IQueryable<TEntity> GetAll() => _table;
    
    public IQueryable<TEntity> GetByExpression(Expression<Func<TEntity, bool>> expression) => _table;

    public async Task CreateAsync(TEntity entity, CancellationToken token = default)
    {
        await _table.AddAsync(entity, token);
        await _context.SaveChangesAsync(token);
    }

    public async Task UpdateAsync(TEntity entity, CancellationToken token = default)
    {
        _table.Update(entity);
        await _context.SaveChangesAsync(token);
    }
}