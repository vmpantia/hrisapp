using HRIS.Core.Requests;

namespace HRIS.Core.Pipelines;

public interface IPipeline<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    public delegate Task<TResponse> RequestHandlerDelegate<TResponse>();
    Task<TResponse> HandleAsync(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken = default);
}