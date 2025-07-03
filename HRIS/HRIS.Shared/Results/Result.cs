namespace HRIS.Shared.Results;

public class Result<TData, TError>
    where TData : class
    where TError : Error
{
    private Result(TData data)
    {
        Data = data;
        Error = null;
        IsSuccess = true;
    }

    private Result(TError error)
    {
        Data = default;
        Error = error;
        IsSuccess = false;
    }

    public TData? Data { get; init; }
    public TError? Error { get; init; }
    public bool IsSuccess { get; init; }

    public static implicit operator Result<TData, TError>(TData data) => new(data);
    public static implicit operator Result<TData, TError>(TError error) => new(error);
}