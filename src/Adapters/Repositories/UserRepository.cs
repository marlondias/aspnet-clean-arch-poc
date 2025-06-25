using CleanArchPOC.Domain.Contracts.Repository;
using CleanArchPOC.Domain.Entities;
using CleanArchPOC.Domain.ValueObjects;

namespace CleanArchPOC.Adapters.Services;

public sealed class UserRepository : IUserCommandsRepository, IUserQueriesRepository
{

    public Task Insert(User entity)
    {
        throw new NotImplementedException();
    }

    public Task Update(User entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteById(int entityId)
    {
        throw new NotImplementedException();
    }

    public Task<User> FindById(int entityId)
    {
        throw new NotImplementedException();
    }

    public Task<User> FindByEmail(EmailAddress emailAddress)
    {
        throw new NotImplementedException();
    }

    public Task<User[]> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsEmailAddressAlreadyInUse(EmailAddress emailAddress)
    {
        throw new NotImplementedException();
    }

}
