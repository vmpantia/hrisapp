using HRIS.Infrastructure.Databases.Contexts;
using HRIS.Infrastructure.Databases.Entities;
using HRIS.Infrastructure.Databases.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace HRIS.Infrastructure.Databases.Repositories;

public sealed class UserRepository(HRISDbContext context) : BaseRepository<User>(context), IUserRepository
{
    public async Task<User?> GetUserAsync(string usernameOrEmail, CancellationToken cancellationToken = default)
    {
        var result = await GetByExpression(u => u.Email.Equals(usernameOrEmail) || u.Username.Equals(usernameOrEmail))
            .SingleOrDefaultAsync(cancellationToken);

        return result;
    }
}