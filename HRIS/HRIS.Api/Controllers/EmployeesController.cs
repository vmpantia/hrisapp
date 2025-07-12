using HRIS.Core.Employees;
using HRIS.Core.Requests;
using HRIS.Shared.Models.Employees;
using HRIS.Shared.Results;
using Microsoft.AspNetCore.Mvc;

namespace HRIS.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeesController(IRequestSender sender) : BaseController(sender)
{
    [HttpGet]
    public async Task<IActionResult> GetEmployeesAsync()
    {
        var result = await SendRequestAsync<GetEmployeesQuery, Result<IEnumerable<EmployeeDto>, Error>>(new GetEmployeesQuery());
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateEmployeeAsync([FromBody] CreateEmployeeDto request)
    {
        var result = await SendRequestAsync<CreateEmployeeCommand, Result<EmployeeDto, Error>>(new CreateEmployeeCommand(request));
        return Ok(result);
    }
}