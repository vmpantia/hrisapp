using AutoMapper;
using HRIS.Infrastructure.Databases.Entities;
using HRIS.Infrastructure.Databases.Repositories.Contracts;
using HRIS.Shared.Models.Employees;
using HRIS.Shared.Results;
using MediatR;

namespace HRIS.Core.Employees;

public sealed class GetEmployeesQuery : IRequest<Result<IEnumerable<EmployeeDto>>>;

public sealed class GetEmployeesQueryHandler(IEmployeeRepository repository, IMapper mapper) : IRequestHandler<GetEmployeesQuery, Result<IEnumerable<EmployeeDto>>>
{
    public async Task<Result<IEnumerable<EmployeeDto>>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
    {
        var employees = await repository.GetEmployeesAsync(null, cancellationToken);
        var result = mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(employees);
        return result.ToList();
    }
}