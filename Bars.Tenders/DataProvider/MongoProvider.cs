using DataProvider.Domain;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DataProvider
{
    /// <summary>
    /// Класс для взаимодействия с MongoDb
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности</typeparam>
    public class MongoProvider<TEntity>
    {
        private readonly IRepository<TEntity> _repository;

        public MongoProvider(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task<TEntity?> Load(ObjectId id, bool asBaseCollection = false)
        {
            return await _repository.Get(id, asBaseCollection);
        }

        public async Task Save(TEntity entity, bool asBaseCollection = false)
        {
            await _repository.SaveOrUpdate(entity, asBaseCollection);
        }

        public async Task<IEnumerable<TEntity?>> LoadAll(bool asBaseCollection = false)
        {
            return await _repository.GetAll(asBaseCollection);
        }

        public async Task Delete(TEntity entity, bool asBaseCollection = false)
        {
            await _repository.Delete(entity, asBaseCollection);
        }

        public IMongoDatabase GetDatabase()
        {
            return _repository.GetDatabase();
        }
    }
}
