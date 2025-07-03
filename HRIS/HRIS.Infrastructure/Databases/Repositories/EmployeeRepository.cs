using System.Linq.Expressions;
using HRIS.Infrastructure.Databases.Contexts;
using HRIS.Infrastructure.Databases.Entities;
using HRIS.Infrastructure.Databases.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace HRIS.Infrastructure.Databases.Repositories;

public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(HRISDbContext context) : base(context) { }

    public async Task<IEnumerable<Employee>> GetEmployeesAsync(Expression<Func<Employee, bool>>? expression, CancellationToken token = default)
    {
        var employees = expression is null ? 
            GetAll() : GetByExpression(expression);

        return await employees
            .Include(tbl => tbl.Contacts)
            .Include(tbl => tbl.Addresses)
            .AsSplitQuery()
            .AsNoTracking()
            .ToListAsync(token);
    }
}