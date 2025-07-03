using HRIS.Shared.Enumerations;

namespace HRIS.Shared.Results;

public class Error(ErrorType Type, string Message, object? Value = null);
