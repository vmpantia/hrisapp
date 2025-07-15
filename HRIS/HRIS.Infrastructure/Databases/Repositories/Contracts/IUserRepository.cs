using HRIS.Infrastructure.Databases.Entities;

namespace HRIS.Infrastructure.Databases.Repositories.Contracts;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> GetUserAsync(string usernameOrEmail, CancellationToken cancellationToken = default);
}