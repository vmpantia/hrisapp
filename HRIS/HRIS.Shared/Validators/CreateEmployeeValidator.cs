using FluentValidation;
using HRIS.Shared.Models.Employees;

namespace HRIS.Shared.Validators;

public class CreateEmployeeValidator : AbstractValidator<CreateEmployeeDto>
{
    public CreateEmployeeValidator()
    {
        RuleFor(e => e.FirstName).NotEmpty();
        RuleFor(e => e.LastName).NotEmpty();
        RuleFor(e => e.Gender).NotNull();
        RuleFor(e => e.BirthDate)
            .NotNull()
            .Must(value => value <= DateTime.Today)
            .WithMessage("Birthday must be less than today");
    }
}