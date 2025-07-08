using AutoMapper;
using HRIS.Infrastructure.Databases.Entities;
using HRIS.Shared.Models.Employees;

namespace HRIS.Core.Employees;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<Employee, EmployeeDto>();
        CreateMap<CreateEmployeeDto, Employee>();
    }
}