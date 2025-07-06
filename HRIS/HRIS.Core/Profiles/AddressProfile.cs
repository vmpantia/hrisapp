using AutoMapper;
using HRIS.Infrastructure.Databases.Entities;
using HRIS.Shared.Models.Addresses;
using HRIS.Shared.Models.Employees;

namespace HRIS.Core.Profiles;

public class AddressProfile : Profile
{
    public AddressProfile()
    {
        CreateMap<Address, AddressDto>();
    }
}