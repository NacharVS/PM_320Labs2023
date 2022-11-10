using DataProvider.Domain;

namespace DataProvider
{
    public class MongoProvider<TEntity>
    {
        private readonly IRepository<TEntity> _repository;

        public MongoProvider(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task Save(TEntity entity)
        {
            await _repository.SaveOrUpdate(entity);
        }

        public async Task<IEnumerable<TEntity?>> LoadAll()
        {
            return await _repository.GetAll();
        }

        public async Task Delete(TEntity entity)
        {
            await _repository.Delete(entity);
        }
    }
}
