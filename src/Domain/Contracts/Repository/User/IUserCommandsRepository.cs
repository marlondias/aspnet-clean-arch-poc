using Domain.Entities;

namespace Domain.Contracts.Repository;

public interface IUserCommandsRepository : ICommandsRepository
{
    public Task Insert(User user);

    public Task Update(User user);

    public Task DeleteById(int id);
}
