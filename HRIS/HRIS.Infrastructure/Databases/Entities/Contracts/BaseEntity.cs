using System.ComponentModel.DataAnnotations.Schema;

namespace HRIS.Infrastructure.Databases.Entities.Contracts;

public class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; }
    public DateTime? ModifiedAt { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }
    [NotMapped] public bool IsDeleted =>  DeletedAt is not null && !string.IsNullOrEmpty(DeletedBy);
}