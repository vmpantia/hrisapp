using HRIS.Core.Requests;

namespace HRIS.Core.Pipelines;

public class PipelineExecutor<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IPipeline<TRequest, TResponse>> _pipelines;
    private readonly IRequestHandler<TRequest, TResponse> _handler;

    public PipelineExecutor(
        IEnumerable<IPipeline<TRequest, TResponse>> pipelines,
        IRequestHandler<TRequest, TResponse> handler)
    {
        _pipelines = pipelines.Reverse(); // Reverse to wrap in correct order
        _handler = handler;
    }

    public Task<TResponse> ExecuteAsync(TRequest request, CancellationToken cancellationToken = default)
    {
        IPipeline<TRequest, TResponse>.RequestHandlerDelegate<TResponse> handlerDelegate = () =>
            _handler.HandleAsync(request, cancellationToken);

        foreach (var pipeline in _pipelines)
        {
            var next = handlerDelegate;
            handlerDelegate = () => pipeline.HandleAsync(request, next, cancellationToken);
        }

        return handlerDelegate();
    }
}