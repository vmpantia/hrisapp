using AutoMapper;
using HRIS.Core.Requests;
using HRIS.Infrastructure.Databases.Entities;
using HRIS.Infrastructure.Databases.Repositories.Contracts;
using HRIS.Shared.Models.Employees;
using HRIS.Shared.Results;

namespace HRIS.Core.Queries.Employees;

public class GetEmployeesQuery : IRequest<Result<IEnumerable<EmployeeDto>, Error>>;

public class GetEmployeesQueryHandler(IEmployeeRepository repository, IMapper mapper) : IRequestHandler<GetEmployeesQuery, Result<IEnumerable<EmployeeDto>, Error>>
{
    public async Task<Result<IEnumerable<EmployeeDto>, Error>> HandleAsync(GetEmployeesQuery request, CancellationToken token = default)
    {
        var employees = await repository.GetEmployeesAsync(null, token);
        var result = mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(employees);
        return result.ToList();
    }
}