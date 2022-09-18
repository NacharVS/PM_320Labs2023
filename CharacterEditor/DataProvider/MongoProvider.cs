using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Editor.Core;
using MongoDB.Driver;

namespace DataProvider
{
    public class MongoProvider
    {
        private CharacterRepository _repository;

        public MongoProvider(string connectionString)
        {
            _repository = new CharacterRepository(new 
                MongoConnection<CharacterDb>(connectionString, "Characters", "CharactersCollection"));
        }

        public void Save(Character character)
        {
            _repository.SaveOrUpdate(character);
        }

        public Character? Load(string name)
        {
            return _repository.GetByName(name);
        }

        public void Delete(Character entity)
        {
            _repository.Delete(entity);
        }
    }
}
