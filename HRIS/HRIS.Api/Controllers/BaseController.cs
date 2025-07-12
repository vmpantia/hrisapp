using FluentValidation;
using HRIS.Core.Requests;
using HRIS.Shared.Results;
using Microsoft.AspNetCore.Mvc;

namespace HRIS.Api.Controllers;

public class BaseController : ControllerBase
{
    private readonly IRequestSender _sender;
    protected BaseController(IRequestSender sender) => _sender = sender;
    
    protected async Task<IActionResult> SendRequestAsync<TRequest, TResponse>(TRequest request)
        where TRequest : IRequest<TResponse>
        where TResponse : class
    {
        try
        {
            // Send a request to command or query
            var result = (Result<TResponse, Error>)await _sender.SendAsync<TRequest, TResponse>(request);

            if (result.IsSuccess) return Ok(result); 
            return BadRequest(result);
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Errors);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}