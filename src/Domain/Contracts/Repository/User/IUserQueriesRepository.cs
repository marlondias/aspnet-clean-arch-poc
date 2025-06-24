using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Contracts.Repository;

public interface IUserQueriesRepository : IQueriesRepository<User>
{
    public Task<User> FindByEmail(EmailAddress emailAddress);

    public Task<bool> IsEmailAddressAlreadyInUse(EmailAddress emailAddress);
}
