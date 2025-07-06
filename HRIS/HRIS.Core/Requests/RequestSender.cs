using HRIS.Core.Pipelines;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace HRIS.Core.Requests;

public class RequestSender(IServiceProvider serviceProvider, ILogger<RequestSender> logger) : IRequestSender
{
    public async Task<TResponse> SendAsync<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken = default) where TRequest : IRequest<TResponse>
    {
        try
        {
            // Get request handler and pipelines based on the TRequest and TResponse
            var handler = (IRequestHandler<TRequest, TResponse>)serviceProvider.GetService(typeof(IRequestHandler<TRequest, TResponse>))!;
            var pipelines = (IEnumerable<IPipeline<TRequest, TResponse>>)serviceProvider.GetServices(typeof(IPipeline<TRequest, TResponse>));
        
            // Check if the handler is NULL
            if (handler is null) throw new Exception($"Request handler for {typeof(TRequest).Name} request is not registered on the system.");

            var executor = new PipelineExecutor<TRequest, TResponse>(pipelines, handler);
            return await executor.ExecuteAsync(request, cancellationToken);
        }
        catch(Exception ex)
        {
            logger.LogError($"Error on handling {typeof(TRequest).Name} request due to: {ex.Message}");
            throw;
        }
    }
}