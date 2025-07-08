using HRIS.Shared.Enumerations;
using HRIS.Shared.Models.Addresses;
using HRIS.Shared.Models.Contacts;

namespace HRIS.Shared.Models.Employees;

public class CreateEmployeeDto
{
    public string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string LastName { get; set; }
    public GenderType Gender { get; set; }
    public DateTime BirthDate { get; set; }
    
    public IEnumerable<CreateContactDto> Contacts { get; set; }
    public IEnumerable<CreateAddressDto> Addresses { get; set; }
}