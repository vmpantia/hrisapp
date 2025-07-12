using HRIS.Shared.Enumerations;

namespace HRIS.Shared.Results;

public record Error(ErrorType Type, string Message, object? Value = null);
