using MongoDB.Bson;

namespace DataProvider.Domain;

public interface IRepository<T>
{
    public Task<T?> Get(ObjectId id);
    public Task<IEnumerable<T?>> GetAll();

    public Task Delete(T entity);
    public Task Update(T entity);
    public Task Save(T entity);
    public Task SaveOrUpdate(T entity);
}