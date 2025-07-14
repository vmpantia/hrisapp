using HRIS.Infrastructure.Databases.Entities.Contracts;

namespace HRIS.Infrastructure.Databases.Entities;

public class Department : BaseEntity, IIdentityEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
    public virtual ICollection<Employment> Employments { get; set; }
}