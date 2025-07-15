using HRIS.Infrastructure.Databases.Entities;
using HRIS.Shared.Models.Users;

namespace HRIS.Core.Users.Contracts;

public interface ITokenProvider
{
    UserTokenDto Create(User user);
}