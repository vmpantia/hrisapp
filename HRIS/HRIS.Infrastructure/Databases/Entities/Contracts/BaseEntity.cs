using System.ComponentModel.DataAnnotations.Schema;

namespace HRIS.Infrastructure.Databases.Entities.Contracts;

public class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime ModifiedOn { get; set; }
    public DateTime? DeletedOn { get; set; }
    [NotMapped] public bool IsDeleted =>  DeletedOn == null;
}