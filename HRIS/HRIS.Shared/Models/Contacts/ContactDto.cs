using HRIS.Shared.Enumerations;

namespace HRIS.Shared.Models.Contacts;

public class ContactDto
{
    public Guid EmployeeId { get; set; }
    public ContactType Type { get; set; }
    public string Value { get; set; }
    public bool IsPrimary { get; set; }
}