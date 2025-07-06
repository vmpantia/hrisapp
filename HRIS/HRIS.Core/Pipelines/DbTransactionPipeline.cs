using System.Transactions;
using HRIS.Core.Requests;

namespace HRIS.Core.Pipelines;

public class DbTransactionPipeline<TRequest, TResponse> : IPipeline<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> HandleAsync(TRequest request, IPipeline<TRequest, TResponse>.RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken = default)
    {
        // Skip pipeline once the request name is not ends with Command
        if (!typeof(TRequest).Name.EndsWith("Command")) 
            return await next();

        // Create transaction scope
        using var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
        
        // Process the next pipeline
        var response = await next();

        // Complete all the transaction
        transactionScope.Complete();

        return response;
    }
}