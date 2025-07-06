using Microsoft.Extensions.Logging;

namespace HRIS.Core.Requests;

public class RequestSender(IServiceProvider serviceProvider, ILogger<RequestSender> logger) : IRequestSender
{
    public async Task<TResponse> SendAsync<TRequest, TResponse>(TRequest request) where TRequest : IRequest<TResponse>
    {
        try
        {
            // Get request handler based on the TRequest and TResponse
            var handler = (IRequestHandler<TRequest, TResponse>)serviceProvider.GetService(typeof(IRequestHandler<TRequest, TResponse>))!;
        
            // Check if the handler is NULL
            if (handler is null) throw new Exception($"Request handler for {typeof(TRequest).Name} request is not registered on the system.");

            return await handler.HandleAsync(request);
        }
        catch(Exception ex)
        {
            logger.LogError($"Error on handling {typeof(TRequest).Name} request due to: {ex.Message}");
            throw;
        }
    }
}