using AutoMapper;
using HRIS.Infrastructure.Databases.Entities;
using HRIS.Shared.Models.Employees;

namespace HRIS.Core.Profiles;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<Employee, EmployeeDto>();
    }
}