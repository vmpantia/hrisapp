using HRIS.Shared.Enumerations;

namespace HRIS.Shared.Models.Contacts;

public sealed class ContactDto
{
    public Guid EmployeeId { get; set; }
    public ContactType Type { get; set; }
    public string Value { get; set; }
    public bool IsPrimary { get; set; }
    
    public DateTime LastModifiedAt { get; set; }
    public string LastModifiedBy { get; set; }
}