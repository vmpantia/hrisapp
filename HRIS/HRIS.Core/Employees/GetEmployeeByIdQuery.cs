using AutoMapper;
using HRIS.Infrastructure.Databases.Repositories.Contracts;
using HRIS.Shared.Models.Employees;
using HRIS.Shared.Results;
using HRIS.Shared.Results.Errors;
using MediatR;

namespace HRIS.Core.Employees;

public sealed record GetEmployeeByIdQuery(Guid Id) : IRequest<Result<EmployeeDto>>;

public sealed class GetEmployeeByIdQueryHandler(IEmployeeRepository repository, IMapper mapper) : IRequestHandler<GetEmployeeByIdQuery, Result<EmployeeDto>>
{
    public async Task<Result<EmployeeDto>> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        var employee = await repository.GetEmployeeAsync(request.Id, cancellationToken);

        // Check if an employee exists on the database
        if (employee is null) return EmployeeError.NotFound(request.Id);
        
        return mapper.Map<EmployeeDto>(employee);
    }
}

