
namespace HRIS.Shared.Models.Addresses;

public class AddressDto
{
    public Guid EmployeeId { get; set; }
    public string Line1 { get; set; }
    public string Line2 { get; set; }
    public string City { get; set; }
    public string Barangay { get; set; }
    public string Province { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }

    public string FullAddress => $"{Line1}, {Line2}, {Barangay}, {City}, {Province}, {PostalCode}, {Country}";
}