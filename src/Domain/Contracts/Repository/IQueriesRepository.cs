namespace Domain.Contracts.Repository;

public interface IQueriesRepository<T>
{
    public Task<T> FindById(int entityId);

    public Task<T[]> GetAll();
}
