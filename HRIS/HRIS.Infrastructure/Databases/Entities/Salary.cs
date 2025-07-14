using HRIS.Infrastructure.Databases.Entities.Contracts;

namespace HRIS.Infrastructure.Databases.Entities;

public class Salary : BaseEntity, IIdentityEntity
{
    public Guid Id { get; set; }
    public Guid EmployeeId { get; set; }
    public decimal BasicPay { get; set; }
    public decimal? DeMinimis { get; set; }
    public decimal? PercentageIncrease { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string Note { get; set; }
    
    public virtual Employment Employment { get; set; }
}