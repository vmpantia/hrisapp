using FluentValidation;
using HRIS.Shared.Enumerations;
using HRIS.Shared.Extensions;
using HRIS.Shared.Results;
using HRIS.Shared.Results.Errors;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HRIS.Api.Controllers;

public class BaseController : ControllerBase
{
    private readonly IMediator _mediator;
    protected BaseController(IMediator mediator) => _mediator = mediator;
    
    protected async Task<IActionResult> SendRequestAsync<TResponse>(IRequest<Result<TResponse>> request) 
        where TResponse : class
    {
        try
        {
            // Send a request to command or query
            var result = await _mediator.Send(request);
            
            return result switch
            {
                { IsSuccess: false, Error: { Type: ErrorType.NotFound } } => NotFound(result),
                { IsSuccess: false } => BadRequest(result),
                _ => Ok(result)
            };
        }
        catch (ValidationException ex)
        {
            var error = DefaultError.Validation(ex.Errors.ToDictionary());
            return BadRequest((Result<TResponse>)error);
        }
        catch (Exception ex)
        {
            return BadRequest((Result<TResponse>)DefaultError.Unexpected(ex));
        }
    }
}