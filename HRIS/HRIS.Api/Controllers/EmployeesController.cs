using HRIS.Core.Employees.Commands;
using HRIS.Core.Employees.Queries;
using HRIS.Shared.Enumerations;
using HRIS.Shared.Models.Employees;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRIS.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeesController(IMediator mediator) : BaseController(mediator)
{
    [HttpGet, Authorize(Roles = nameof(UserType.Admin))]
    public async Task<IActionResult> GetEmployeesAsync() => await SendRequestAsync(new GetEmployeesQuery());
    
    [HttpGet("{id}"), Authorize(Roles = nameof(UserType.Admin))] 
    public async Task<IActionResult> GetEmployeeByIdAsync(Guid id) => await SendRequestAsync(new GetEmployeeByIdQuery(id));
    
    [HttpPost, Authorize(Roles = nameof(UserType.Admin))] 
    public async Task<IActionResult> CreateEmployeeAsync([FromBody] CreateEmployeeDto request) => await SendRequestAsync(new CreateEmployeeCommand(request));
    
    [HttpDelete("{id}"), Authorize(Roles = nameof(UserType.Admin))] 
    public async Task<IActionResult> DeleteEmployeeAsync(Guid id) => await SendRequestAsync(new DeleteEmployeeByIdCommand(id));
}