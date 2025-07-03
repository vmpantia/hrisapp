using HRIS.Infrastructure.Databases.Entities.Contracts;

namespace HRIS.Infrastructure.Databases.Entities;

public class Address : BaseEntity
{
    public Guid EmployeeId { get; set; }
    public string Line1 { get; set; }
    public string Line2 { get; set; }
    public string City { get; set; }
    public string Barangay { get; set; }
    public string Province { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
    
    public virtual Employee Employee { get; set; }
}