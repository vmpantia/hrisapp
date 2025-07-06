namespace HRIS.Core.Requests;

public static class RequestExtension
{
    public static string GetName<TRequest, TResponse>(this TRequest request) where TRequest : IRequest<TResponse> =>
        typeof(TRequest).Name;
}