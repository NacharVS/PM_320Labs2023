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

            Character character;

            switch (dbCharacter.ClassName)
            {
                case "Warrior":
                    character = new Warrior(dbCharacter.Strength,
                                        dbCharacter.Dexterity,
                                        dbCharacter.Constitution,
                                        dbCharacter.Intellisense,
                                        dbCharacter.Experience,
                                        dbCharacter.AvailableAbilityCount);
                    break;
                case "Wizard":
                    character =  new Wizard(dbCharacter.Strength,
                                        dbCharacter.Dexterity,
                                        dbCharacter.Constitution,
                                        dbCharacter.Intellisense,
                                        dbCharacter.Experience,
                                        dbCharacter.AvailableAbilityCount);
                    break;
                case "Rogue":
                    character = new Rogue(dbCharacter.Strength,
                                        dbCharacter.Dexterity,
                                        dbCharacter.Constitution,
                                        dbCharacter.Intellisense,
                                        dbCharacter.Experience,
                                        dbCharacter.AvailableAbilityCount);
                    break;
                default: return null;
            }

            character.Name = dbCharacter.Name;
            character.Inventory = new Inventory(dbCharacter.Items);
            character.Abilities = dbCharacter.Abilities;
            return character;
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
                                character.Abilities,
                                character.AvailableAbilityCount);
        }
    }
}