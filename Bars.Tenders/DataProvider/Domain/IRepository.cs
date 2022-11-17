using MongoDB.Bson;
using MongoDB.Driver;

namespace DataProvider.Domain;

/// <summary>
/// Репозиторий, реализующий все CRUD операции
/// </summary>
/// <typeparam name="T">Тип сущности</typeparam>
public interface IRepository<T>
{
    public Task<T?> Get(ObjectId id, bool asBaseCollection = false);
    public Task<IEnumerable<T?>> GetAll(bool asBaseCollection = false);

    public Task Delete(T entity, bool asBaseCollection = false);
    public Task Update(T entity, bool asBaseCollection = false);
    public Task Save(T entity, bool asBaseCollection = false);
    public Task SaveOrUpdate(T entity, bool asBaseCollection = false);

    public IMongoDatabase GetDatabase();
}