using HRIS.Shared.Enumerations;

namespace HRIS.Shared.Results.Errors;

public sealed record Error(ErrorType Type, string Message, object? Value = null);
