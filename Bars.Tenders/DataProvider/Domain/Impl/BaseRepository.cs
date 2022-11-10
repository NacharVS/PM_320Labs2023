using Core.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DataProvider.Domain.Impl;

public class BaseRepository<TEntity> : IRepository<TEntity>
    where TEntity : BaseEntity
{
    private readonly MongoConnection<TEntity> _connection;

    public BaseRepository(MongoConnection<TEntity> connection)
    {
        _connection = connection;
    }

    public async Task<TEntity?> Get(ObjectId id)
    {
        return (await _connection.Collection.FindAsync(x => x._id == id)).FirstOrDefault();
    }
    public async Task<IEnumerable<TEntity?>> GetAll()
    {
        return (await _connection.Collection.FindAsync(_ => true)).ToList();;
    }

    public async Task Delete(TEntity entity)
    {
        await _connection.Collection.DeleteOneAsync(x => x._id == entity._id);
    }

    public async Task Update(TEntity entity)
    {
        await _connection.Collection.ReplaceOneAsync(x => x._id == entity._id, 
            entity);
    }

    public async Task Save(TEntity entity)
    {
        entity._id = ObjectId.GenerateNewId();
        await _connection.Collection.InsertOneAsync(entity);
    }

    public async Task SaveOrUpdate(TEntity entity)
    {
        if ((await _connection.Collection.
                FindAsync(x => 
                    x._id == entity._id)).FirstOrDefault() != null)
        {
            await Update(entity);
        }
        else
        {
            await Save(entity);
        }
    }
}