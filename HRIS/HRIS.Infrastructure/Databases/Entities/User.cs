using HRIS.Infrastructure.Databases.Entities.Contracts;
using HRIS.Shared.Enumerations;

namespace HRIS.Infrastructure.Databases.Entities;

public class User : BaseEntity, IIdentityEntity
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public UserType Type { get; set; }
}