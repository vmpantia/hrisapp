using AutoMapper;
using HRIS.Infrastructure.Databases.Entities;
using HRIS.Shared.Models.Contacts;

namespace HRIS.Core.Contacts;

public class ContactProfile : Profile
{
    public ContactProfile()
    {
        CreateMap<Contact, ContactDto>();
        CreateMap<CreateContactDto, Contact>();
    }
}