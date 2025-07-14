using HRIS.Infrastructure.Databases.Entities.Contracts;
using HRIS.Shared.Enumerations;

namespace HRIS.Infrastructure.Databases.Entities;

public class Employee : BaseEntity, IIdentityEntity
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string LastName { get; set; }
    public GenderType Gender { get; set; }
    public DateTime BirthDate { get; set; }
    
    public virtual ICollection<Contact> Contacts { get; set; }
    public virtual ICollection<Address> Addresses { get; set; }
    public virtual Employment Employment { get; set; }
}