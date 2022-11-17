using Core.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DataProvider.Domain.Impl;

/// <summary>
/// Базовая реализация репозитория
/// </summary>
/// <typeparam name="TEntity">Тип сущности</typeparam>
public class BaseRepository<TEntity> : IRepository<TEntity>
    where TEntity : BaseEntity
{
    private readonly MongoConnection<TEntity> _connection;

    public BaseRepository(IConfiguration configuration)
    {
        _connection = new MongoConnection<TEntity>(configuration);
    }

    public async Task<TEntity?> Get(ObjectId id, bool asBaseCollection = false)
    {
        var collection = asBaseCollection ? _connection.GetBaseCollection() : _connection.Collection;
        return (await collection.FindAsync(x => x._id == id)).FirstOrDefault();
    }
    public async Task<IEnumerable<TEntity?>> GetAll(bool asBaseCollection = false)
    {
        var collection = asBaseCollection ? _connection.GetBaseCollection() : _connection.Collection;
        return (await collection.FindAsync(_ => true)).ToList();
    }

    public async Task Delete(TEntity entity, bool asBaseCollection = false)
    {
        var collection = asBaseCollection ? _connection.GetBaseCollection() : _connection.Collection;
        await collection.DeleteOneAsync(x => x._id == entity._id);
    }

    public async Task Update(TEntity entity, bool asBaseCollection = false)
    {
        var collection = asBaseCollection ? _connection.GetBaseCollection() : _connection.Collection;
        await collection.ReplaceOneAsync(x => x._id == entity._id, entity);
    }

    public async Task Save(TEntity entity, bool asBaseCollection = false)
    {
        entity._id = ObjectId.GenerateNewId();
        var collection = asBaseCollection ? _connection.GetBaseCollection() : _connection.Collection;
        await collection.InsertOneAsync(entity);
    }

    public async Task SaveOrUpdate(TEntity entity, bool asBaseCollection = false)
    {
        var collection = asBaseCollection ? _connection.GetBaseCollection() : _connection.Collection;
        if ((await collection.
                FindAsync(x => 
                    x._id == entity._id)).FirstOrDefault() != null)
        {
            await Update(entity, asBaseCollection);
        }
        else
        {
            await Save(entity, asBaseCollection);
        }
    }

    public IMongoDatabase GetDatabase()
    {
        return _connection.Database;
    }
}