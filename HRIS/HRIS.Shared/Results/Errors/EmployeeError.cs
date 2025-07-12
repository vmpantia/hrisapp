using HRIS.Shared.Enumerations;

namespace HRIS.Shared.Results.Errors;

public abstract class EmployeeError
{
    public static Error NotFound(Guid id) => new(ErrorType.NotFound, $"Employee with an ID of {id} is not found in the database.");
}