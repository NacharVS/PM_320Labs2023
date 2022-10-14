using CharacterEditorCore;
using CharacterEditorCore.Items;
using CharacterEditorCore.Match;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace CharacterEditorMongoDb
{
    public class CharacterRepository : ICharacterRepository
    {
        private IMongoCollection<CharacterDb> _characters;

        public CharacterRepository(DBConnection dbConnection)
        {
            BsonClassMap.RegisterClassMap<Helmet>();
            BsonClassMap.RegisterClassMap<Rifle>();
            BsonClassMap.RegisterClassMap<Bow>();
            BsonClassMap.RegisterClassMap<Knife>();
            BsonClassMap.RegisterClassMap<Item>();
            BsonClassMap.RegisterClassMap<Ability>();
            BsonClassMap.RegisterClassMap<Weapon>();
            BsonClassMap.RegisterClassMap<Breastplate>();
            BsonClassMap.RegisterClassMap<Equipment>();

            _characters = dbConnection.Connection.GetCollection<CharacterDb>("Characters");
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
            
            return CreateCharacter(dbCharacter);
        }

        private Character CreateCharacter(CharacterDb dbCharacter)
        {
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
                    character = new Wizard(dbCharacter.Strength,
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
            character.Equipment = dbCharacter.Equipment;

            return character;
        }

        public bool ReplaceByName(string name, Character character)
        {
            return _characters.ReplaceOne(x => x.Name == name, CreateCharacterDb(character)).ModifiedCount > 0;
        }

        public List<MatchCharacterInfo> GetAllCharacters()
        {
            var chars = _characters.Find<CharacterDb>(x => true).ToList();

            var result = new List<MatchCharacterInfo>();

            foreach(var character in chars)
            {
                result.Add(new MatchCharacterInfo()
                {
                    Name = character.Name,
                    Id = character._id.ToString(),
                    Level = LevelInfo.GetLevel(character.Experience)
                });
            }

            return result;
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
                                character.AvailableAbilityCount,
                                character.Equipment);
        }

        public Character GetCharacterById(string id)
        {
            return CreateCharacter(_characters
                .Find(x => x._id.ToString() == id)
                .FirstOrDefault());
        }
    }
}