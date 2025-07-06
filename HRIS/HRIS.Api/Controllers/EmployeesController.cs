using HRIS.Core.Queries.Employees;
using HRIS.Core.Requests;
using HRIS.Infrastructure.Databases.Entities;
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
        var result = await sender.SendAsync<GetEmployeesQuery, Result<IEnumerable<Employee>, Error>>(new GetEmployeesQuery());
        return Ok(result);
    }
}