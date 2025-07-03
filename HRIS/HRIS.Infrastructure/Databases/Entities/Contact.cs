using HRIS.Infrastructure.Databases.Entities.Contracts;
using HRIS.Shared.Enumerations;

namespace HRIS.Infrastructure.Databases.Entities;

public class Contact : BaseEntity
{
    public Guid EmployeeId { get; set; }
    public ContactType Type { get; set; }
    public string Value { get; set; }
    public bool IsPrimary { get; set; }
    
    public virtual Employee Employee { get; set; }
}