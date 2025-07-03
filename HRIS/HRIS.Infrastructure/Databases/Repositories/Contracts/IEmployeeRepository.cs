using System.Linq.Expressions;
using HRIS.Infrastructure.Databases.Entities;

namespace HRIS.Infrastructure.Databases.Repositories.Contracts;

public interface IEmployeeRepository
{
    Task<IEnumerable<Employee>> GetEmployeesAsync(Expression<Func<Employee, bool>>? expression, CancellationToken token = default);
}