using CharacterEditorCore;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace CharacterEditorMongoDb
{
    public class CharacterRepository : ICharacterRepository
    {
        private IMongoCollection<CharacterDb> _characters;

        public CharacterRepository(string? connectionClient, string? databaseStr)
        {
            BsonClassMap.RegisterClassMap<Helmet>();
            BsonClassMap.RegisterClassMap<Armor>();
            BsonClassMap.RegisterClassMap<Rifle>();
            BsonClassMap.RegisterClassMap<Bow>();
            BsonClassMap.RegisterClassMap<Knife>();
            BsonClassMap.RegisterClassMap<Ability>();

            var client = new MongoClient(connectionClient);
            var database = client.GetDatabase(databaseStr);

            _characters = database.GetCollection<CharacterDb>("Characters");
        }

        public List<string> GetCharacterNames()
        {
            var res = _characters.Find<CharacterDb>(x => x.Name != null && x.Name != "")
                                 .ToEnumerable<CharacterDb>();
            return res.Select(x => x.Name).ToList<string>();
        }

        public void InsertCharacter(Character character)
        {
            _characters.InsertOne(CreateCharacterDb(character));
        }

        public bool IsCharacterExist(string name)
        {
            var res = _characters.Find<CharacterDb>(x => x.Name == name)
                                 .ToEnumerable<CharacterDb>()
                                 .Select(x => x.Name)
                                 .ToList<string>();
            
            if (res.Count >= 1)
            {
                return true;
            }
            return false;
        }

        public Character GetCharacterByName(string name)
        {
            var dbCharacter = _characters.Find<CharacterDb>(x => x.Name == name).FirstOrDefault();

            if (dbCharacter == null)
            {
                return null;
            }

            switch (dbCharacter.ClassName)
            {
                case "Warrior":
                    return new Warrior(dbCharacter.Strength,
                                        dbCharacter.Dexterity,
                                        dbCharacter.Constitution,
                                        dbCharacter.Intellisense,
                                        dbCharacter.Experience)
                                        { Name = dbCharacter.Name,
                                          Inventory = new Inventory(dbCharacter.Items)};
                case "Wizard":
                    return new Wizard(dbCharacter.Strength,
                                        dbCharacter.Dexterity,
                                        dbCharacter.Constitution,
                                        dbCharacter.Intellisense,
                                        dbCharacter.Experience)
                                        { Name = dbCharacter.Name,
                                          Inventory = new Inventory(dbCharacter.Items)};
                case "Rogue":
                    return new Rogue(dbCharacter.Strength,
                                        dbCharacter.Dexterity,
                                        dbCharacter.Constitution,
                                        dbCharacter.Intellisense,
                                        dbCharacter.Experience)
                                        { Name = dbCharacter.Name,
                                          Inventory = new Inventory(dbCharacter.Items)};
                default: return null;
            }
        }

        public bool ReplaceByName(string name, Character character)
        {
            return _characters.ReplaceOne(x => x.Name == name, CreateCharacterDb(character)).ModifiedCount > 0;
        }

        private CharacterDb CreateCharacterDb(Character character)
        {
            return new CharacterDb(character.Name,
                                character.GetType().Name,
                                character.GetStrengthValue(),
                                character.GetDexterityValue(),
                                character.GetConstitutionValue(),
                                character.GetIntellisenseValue(),
                                character.Inventory.Items,
                                character.Experience,
                                character.Abilities);
        }
    }
}