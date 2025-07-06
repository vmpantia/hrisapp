namespace HRIS.Core.Requests;

public interface IRequestSender
{
    Task<TResponse> SendAsync<TRequest, TResponse>(TRequest request) where TRequest : IRequest<TResponse>;
}