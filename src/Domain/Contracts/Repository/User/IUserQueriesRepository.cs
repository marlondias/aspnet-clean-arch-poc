using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Contracts.Repository;

public interface IUserQueriesRepository : IQueriesRepository
{
    public Task<User> findById(int id);

    public Task<User> findByEmail(EmailAddress emailAddress);

    public Task<User[]> getAll();
}
