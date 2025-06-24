namespace Domain.Contracts.Repository;

public interface ICommandsRepository<T>
{
    public Task Insert(T entity);

    public Task Update(T entity);

    public Task DeleteById(int entityId);
}
