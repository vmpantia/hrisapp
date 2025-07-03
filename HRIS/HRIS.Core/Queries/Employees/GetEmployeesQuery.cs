using HRIS.Core.Requests;
using HRIS.Infrastructure.Databases.Entities;
using HRIS.Infrastructure.Databases.Repositories.Contracts;

namespace HRIS.Core.Queries.Employees;

public class GetEmployeesQuery : IRequest<IEnumerable<Employee>>;

public class GetEmployeesQueryHandler(IEmployeeRepository repository) : IRequestHandler<GetEmployeesQuery, IEnumerable<Employee>>
{
    public async Task<IEnumerable<Employee>> HandleAsync(GetEmployeesQuery request, CancellationToken token = default)
    {
        var result = await repository.GetEmployeesAsync(null, token);
        return result;
    }
}