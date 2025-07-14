using HRIS.Infrastructure.Databases.Entities.Contracts;
using HRIS.Shared.Enumerations;

namespace HRIS.Infrastructure.Databases.Entities;

public class Employment : BaseEntity
{
    public Guid EmployeeId { get; set; }
    public Guid JobId { get; set; }
    public Guid DepartmentId { get; set; }
    public EmploymentType Type { get; set; } 
    public DateTime HireDate { get; set; }
    public DateTime? RegularizationDate { get; set; }
    public DateTime? EndDate { get; set; }
    
    public virtual Employee Employee { get; set; }
    public virtual Job Job { get; set; }
    public virtual Department Department { get; set; }
    public virtual ICollection<Salary> Salaries { get; set; }
}