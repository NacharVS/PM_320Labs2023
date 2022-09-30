using CharacterEditorCore;
using CharacterEditorCore.Items;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace CharacterEditorMongoDataBase
{
    public class CharacterEditorContext
    {

        public CharacterEditorContext()
        {
            BsonClassMap.RegisterClassMap<Boots>();
            BsonClassMap.RegisterClassMap<Bow>();
            BsonClassMap.RegisterClassMap<Helmet>();
            BsonClassMap.RegisterClassMap<Knife>();
            BsonClassMap.RegisterClassMap<Pistol>();
            BsonClassMap.RegisterClassMap<Ability>();
        }
        public bool AddCharacterToDb(BaseCharacteristics character)
        {
            try
            {
                MongoDataBase.collection.InsertOne(new BaseCharacterrDb
                {
                    Name = character.Name,
                    CharacterClassName = character.GetType().Name,
                    Strength = character.Strength.Value,
                    Dexterity = character.Dexterity.Value,
                    Constitution = character.Constitution.Value,
                    Intelligence = character.Intelligence.Value,
                    Inventory = character.Inventory.Count == 0 ? null : character.Inventory,
                    Experience = character.Lvl.CurrentExp,
                    Abilities = character.Abilities.Count == 0 ? null : character.Abilities
                });

                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool UpdateCharacterInDb(string characterId, BaseCharacteristics character)
        {
            try
            {
                MongoDataBase.collection.ReplaceOne(x => x.Id == characterId,
                new BaseCharacterrDb
                {
                    Name = character.Name,
                    CharacterClassName = character.GetType().Name,
                    Strength = character.Strength.Value,
                    Dexterity = character.Dexterity.Value,
                    Constitution = character.Constitution.Value,
                    Intelligence = character.Intelligence.Value,
                    Inventory = character.Inventory,
                    Experience = character.Lvl.CurrentExp,
                    Abilities = character.Abilities
                });

                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<CharacterIdName> GetAllChars()
        {
            List<CharacterIdName> res = new();
            try
            {
                var characters = MongoDataBase.collection.Find(new BsonDocument()).ToList();

                foreach (var character in characters)
                {
                    res.Add(new CharacterIdName
                    {
                        Id = character.Id,
                        Name = character.Name
                    });
                }
                return res;
            }
            catch
            {
                return res;
            }
        }

        public BaseCharacteristics GetCharacter(string characterId)
        {
            try
            {
                BaseCharacteristics baseCharacter = null;
                var characterDb = MongoDataBase.collection.Find(x => x.Id == characterId).FirstOrDefault();

                if(characterDb is null)
                {
                    return null;
                }

                switch (characterDb.CharacterClassName)
                {
                    case "Warrior":
                        baseCharacter = new Warrior();
                        break;
                    case "Rogue":
                        baseCharacter = new Rogue();
                        break;
                    case "Wizard":
                        baseCharacter = new Wizard();
                        break;
                }
                baseCharacter.Dexterity.Value = characterDb.Dexterity;
                baseCharacter.Intelligence.Value = characterDb.Intelligence;
                baseCharacter.Strength.Value = characterDb.Strength;
                baseCharacter.Constitution.Value = characterDb.Constitution;
                baseCharacter.Inventory = characterDb.Inventory is not null ? characterDb.Inventory : new List<IItem>();
                baseCharacter.Lvl.CurrentExp = characterDb.Experience;
                baseCharacter.Abilities = characterDb.Abilities is not null ? characterDb.Abilities : new List<Ability>();
                return baseCharacter;
            }
            catch 
            {
                return null;
            }
        }
    }
}