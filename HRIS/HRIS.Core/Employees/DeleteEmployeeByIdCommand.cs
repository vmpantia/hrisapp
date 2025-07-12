using AutoMapper;
using HRIS.Infrastructure.Databases.Repositories.Contracts;
using HRIS.Shared.Results;
using HRIS.Shared.Results.Errors;
using MediatR;

namespace HRIS.Core.Employees;

public sealed record DeleteEmployeeByIdCommand(Guid Id) : IRequest<Result<string>>;

public sealed class DeleteEmployeeByIdCommandHandler(IEmployeeRepository repository, IMapper mapper) : IRequestHandler<DeleteEmployeeByIdCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteEmployeeByIdCommand request, CancellationToken cancellationToken)
    {
        // Get employee from the database using id
        var employee = await repository.GetEmployeeAsync(request.Id, cancellationToken);

        // Check if an employee exists on the database
        if (employee is null) return EmployeeError.NotFound(request.Id);
        
        // Delete employee on the database
        await repository.DeleteAsync(employee, cancellationToken);
        
        return "Employee deleted successfully on the database.";
    }
}