using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataProvider.Interfaces;
using Editor.Core;
using MongoDB.Driver;

namespace DataProvider
{
    public class MongoProvider<TEntity>
    {
        private IRepository<TEntity> _repository;

        public MongoProvider(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public void Save(TEntity character)
        {
            _repository.SaveOrUpdate(character);
        }

        public TEntity? Load(string name)
        {
            return _repository.GetByName(name);
        }

        public IEnumerable<TEntity?> LoadAll()
        {
            return _repository.GetAll();
        }

        public void Delete(TEntity entity)
        {
            _repository.Delete(entity);
        }
    }
}
