using HRIS.Infrastructure.Databases.Entities.Contracts;

namespace HRIS.Infrastructure.Databases.Entities;

public class Job : BaseEntity, IIdentityEntity
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal BasePayRangeFrom { get; set; }
    public decimal BasePayRangeTo { get; set; }
    
    public virtual ICollection<Employment> Employments { get; set; }
}