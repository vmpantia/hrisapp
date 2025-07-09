using FluentValidation;
using HRIS.Core.Requests;
using Microsoft.Extensions.DependencyInjection;

namespace HRIS.Core.Pipelines;

public class ValidationPipeline<TRequest, TResponse>(IServiceProvider serviceProvider) : IPipeline<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> HandleAsync(TRequest request, IPipeline<TRequest, TResponse>.RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken = default)
    {
        // Skip pipeline once the request name is not ends with Command
        if (!typeof(TRequest).Name.EndsWith("Command")) 
            return await next();
        
        // Get validator service based on the TRequest
        var validator = serviceProvider.GetService<IValidator<TRequest>>();

        // Check if the validator is not null
        if (validator != null) await validator.ValidateAndThrowAsync(request, cancellationToken);

        return await next();
    }
}