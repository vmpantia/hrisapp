using HRIS.Core.Requests;
using HRIS.Infrastructure.Databases.Entities;
using HRIS.Infrastructure.Databases.Repositories.Contracts;
using HRIS.Shared.Results;

namespace HRIS.Core.Queries.Employees;

public class GetEmployeesQuery : IRequest<Result<IEnumerable<Employee>, Error>>;

public class GetEmployeesQueryHandler(IEmployeeRepository repository) : IRequestHandler<GetEmployeesQuery, Result<IEnumerable<Employee>, Error>>
{
    public async Task<Result<IEnumerable<Employee>, Error>> HandleAsync(GetEmployeesQuery request, CancellationToken token = default)
    {
        var result = await repository.GetEmployeesAsync(null, token);
        return result.ToList();
    }
}