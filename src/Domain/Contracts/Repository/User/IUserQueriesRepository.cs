using CleanArchPOC.Domain.Entities;
using CleanArchPOC.Domain.ValueObjects;

namespace CleanArchPOC.Domain.Contracts.Repository;

public interface IUserQueriesRepository : IQueriesRepository<User>
{
    public Task<User?> FindByEmail(EmailAddress emailAddress);

    public Task<bool> IsEmailAddressAlreadyInUse(EmailAddress emailAddress);
}
