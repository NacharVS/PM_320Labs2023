using DataProvider.Models;
using Editor.Core.Characters.interfaces;
using MongoDB.Driver;

namespace DataProvider.Domain.Impl;

public abstract class BaseRepository<TEntity, TModel> : IRepository<TEntity> 
    where TModel : BaseModel 
    where TEntity : IHaveName
{
    private readonly MongoConnection<TModel> _connection;

    protected BaseRepository(MongoConnection<TModel> connection)
    {
        _connection = connection;
    }

    public TEntity? GetById(string id)
    {
        var entity = _connection.Collection.Find(x => x.Id == id).FirstOrDefault();
        return InitializeEntity(entity);
    }

    public TEntity? GetByName(string name)
    {
        var entity = _connection.Collection.Find(x => x.Name == name).FirstOrDefault();
        return InitializeEntity(entity);
    }

    public IEnumerable<TEntity?> GetAllByName(string name)
    {
        return GetAll().Where(x => x?.Name == name).ToList();
    }

    public IEnumerable<TEntity?> GetAll()
    {
        var models = _connection.Collection.Find(_ => true).ToList();

        var entities = new List<TEntity?>();
        models.ToList().ForEach(x =>
            entities.Add(InitializeEntity(x)));

        return entities;
    }

    public void Delete(TEntity entity)
    {
        _connection.Collection.DeleteOne(x => x.Name == entity.Name);
    }

    public void Update(TEntity entity)
    {
        var dbEntity = _connection.Collection
            .Find(x => x.Name == entity.Name).FirstOrDefault();
        _connection.Collection.ReplaceOne(x => x.Id == dbEntity.Id, 
            GetModelInstance(entity));
    }

    public void Save(TEntity entity)
    {
        _connection.Collection.InsertOne(GetModelInstance(entity));
    }

    public void SaveOrUpdate(TEntity entity)
    {
        if (_connection.Collection.
                Find(x => 
                    x.Name == entity.Name).FirstOrDefault() != null)
        {
            Update(entity);
        }
        else
        {
            Save(entity);
        }
    }

    private TModel GetModelInstance(TEntity entity)
    {
        return ((TModel)Activator.
            CreateInstance(typeof(TModel), Guid.NewGuid().ToString(), entity!)!)!;

    }

    protected abstract TEntity? InitializeEntity(TModel model);

    protected abstract TEntity? CastToEntity(TModel model);
}