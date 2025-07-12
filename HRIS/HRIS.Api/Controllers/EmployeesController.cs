using HRIS.Core.Employees;
using HRIS.Shared.Models.Employees;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HRIS.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeesController(IMediator mediator) : BaseController(mediator)
{
    [HttpGet] public async Task<IActionResult> GetEmployeesAsync() => await SendRequestAsync(new GetEmployeesQuery());
    [HttpGet("{id}")] public async Task<IActionResult> GetEmployeeByIdAsync(Guid id) => await SendRequestAsync(new GetEmployeeByIdQuery(id));
    [HttpPost] public async Task<IActionResult> CreateEmployeeAsync([FromBody] CreateEmployeeDto request) => await SendRequestAsync(new CreateEmployeeCommand(request));
}