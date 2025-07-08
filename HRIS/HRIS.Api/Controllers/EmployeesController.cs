using HRIS.Core.Employees;
using HRIS.Core.Requests;
using HRIS.Shared.Models.Employees;
using HRIS.Shared.Results;
using Microsoft.AspNetCore.Mvc;

namespace HRIS.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeesController(IRequestSender sender) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetEmployeesAsync()
    {
        var result = await sender.SendAsync<GetEmployeesQuery, Result<IEnumerable<EmployeeDto>, Error>>(new GetEmployeesQuery());
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateEmployeeAsync([FromBody] CreateEmployeeDto request)
    {
        var result = await sender.SendAsync<CreateEmployeeCommand, Result<EmployeeDto, Error>>(new CreateEmployeeCommand(request));
        return Ok(result);
    }
}