using AutoMapper;
using HRIS.Infrastructure.Databases.Entities;
using HRIS.Shared.Models.Contacts;
using HRIS.Shared.Models.Employees;

namespace HRIS.Core.Profiles;

public class ContactProfile : Profile
{
    public ContactProfile()
    {
        CreateMap<Contact, ContactDto>();
    }
}