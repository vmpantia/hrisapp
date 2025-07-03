namespace HRIS.Core.Requests;

public interface IRequestHandler<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    Task<TResponse> HandleAsync(TRequest request, CancellationToken token = default);
}

public interface IRequestHandler<TRequest>
    where TRequest : IRequest
{
    Task HandleAsync(TRequest request, CancellationToken token = default);
}