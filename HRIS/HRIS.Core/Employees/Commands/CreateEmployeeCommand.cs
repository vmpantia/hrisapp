using AutoMapper;
using FluentValidation;
using HRIS.Infrastructure.Databases.Entities;
using HRIS.Infrastructure.Databases.Repositories.Contracts;
using HRIS.Shared.Models.Employees;
using HRIS.Shared.Results;
using HRIS.Shared.Validators;
using MediatR;

namespace HRIS.Core.Employees.Commands;

public sealed record CreateEmployeeCommand(CreateEmployeeDto Employee) : IRequest<Result<EmployeeDto>>;

public sealed class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
{
    public CreateEmployeeCommandValidator(IEmployeeRepository employeeRepository)
    {
        RuleFor(cec => cec.Employee)
            .SetValidator(new CreateEmployeeValidator());

        RuleFor(cec => cec.Employee)
            .MustAsync(async (ced, ct) => await employeeRepository.IsExistAsync(e => e.FirstName == ced.FirstName && e.LastName == ced.LastName, ct) == false)
            .WithMessage("Employee first name and last name is already exist in the database.");
    }
}

public sealed class CreateEmployeeCommandHandler(IEmployeeRepository repository, IMapper mapper) : IRequestHandler<CreateEmployeeCommand, Result<EmployeeDto>>
{
    public async Task<Result<EmployeeDto>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken = default)
    {
        // Map request dto to an entity
        var entity = mapper.Map<Employee>(request.Employee);
        
        // Create new entity on the database
        var newEmployee = await repository.CreateAsync(entity,  cancellationToken);
        
        // Map new employee to dto (assuming it has a new primary keys)
        var result = mapper.Map<EmployeeDto>(newEmployee);

        return result;
    }
}