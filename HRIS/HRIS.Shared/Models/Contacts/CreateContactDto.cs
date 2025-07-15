using HRIS.Shared.Enumerations;

namespace HRIS.Shared.Models.Contacts;

public sealed class CreateContactDto
{
    public ContactType Type { get; set; }
    public string Value { get; set; }
    public bool IsPrimary { get; set; }
}