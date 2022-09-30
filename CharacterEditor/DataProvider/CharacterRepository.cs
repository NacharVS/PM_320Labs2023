using DataProvider.Interfaces;
using Editor.Core;
using MongoDB.Driver;

namespace DataProvider
{
    public class CharacterRepository : IRepository<Character>
    {
        private readonly MongoConnection<CharacterDb> _connection;

        public CharacterRepository(MongoConnection<CharacterDb> connection)
        {
            _connection = connection;
        }

        public Character? GetById(int id)
        {
            var entity = _connection.Collection.Find(x => x.Id == id).FirstOrDefault();
            return InitializeCharacter(entity);
        }

        public Character? GetByName(string name)
        {
            var entity = _connection.Collection.Find(x => x.Name == name).FirstOrDefault();
            return InitializeCharacter(entity);
        }

        public IEnumerable<Character?> GetAllByName(string name)
        {
            var entityCollection = _connection.Collection.Find(x => x.Name == name);
            var characterCollection = new List<Character?>();
            entityCollection.ToList().ForEach(x => 
                characterCollection.Add(InitializeCharacter(x)));

            return characterCollection;
        }

        public void Delete(Character entity)
        {
            _connection.Collection.DeleteOne(x => x.Name == entity.GetType().ToString());
        }

        public void Update(Character entity)
        {
            var dbCharacter = _connection.Collection
                .Find(x => x.Name == entity.GetType().ToString()).FirstOrDefault();
            _connection.Collection.ReplaceOne(x => x.Id == dbCharacter.Id, 
                new CharacterDb(dbCharacter.Id, entity));
        }

        public void Save(Character entity)
        {
            _connection.Collection.InsertOne(new CharacterDb(entity.GetHashCode(), entity));
        }

        public void SaveOrUpdate(Character entity)
        {
            if (_connection.Collection.
                    Find(x => 
                        x.Name == entity.GetType().ToString()).FirstOrDefault() != null)
            {
                Update(entity);
            }
            else
            {
                Save(entity);
            }
        }

        private Character? InitializeCharacter(CharacterDb entity)
        {
            return CastToCharacter(entity);
        }

        private Character? CastToCharacter(CharacterDb entity)
        {
            switch (entity?.Name?.Split('.')[^1])
            {
                case "Warrior":
                    return new Warrior(entity.AvailableSkillPoints, entity.Experience, entity.Strength, 
                        entity.Dexterity, entity.Constitution, entity.Intelligence);
                case "Rogue":
                    return new Rogue(entity.AvailableSkillPoints, entity.Experience, entity.Strength, 
                        entity.Dexterity, entity.Constitution, entity.Intelligence);
                case "Wizard":
                    return new Wizard(entity.AvailableSkillPoints, entity.Experience, entity.Strength, 
                        entity.Dexterity, entity.Constitution, entity.Intelligence);
            }
            return null;
        }
    }
}
