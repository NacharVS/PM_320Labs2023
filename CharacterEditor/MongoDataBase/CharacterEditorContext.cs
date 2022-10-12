using CharacterEditorCore;
using CharacterEditorCore.DataBase;
using CharacterEditorCore.Items;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace CharacterEditorMongoDataBase
{
    public class CharacterEditorContext : ICharacterRep
    {

        public CharacterEditorContext()
        {
            BsonClassMap.RegisterClassMap<Ability>();
            BsonClassMap.RegisterClassMap<Item>();
        }
        public bool AddCharacterToDb(BaseCharacteristics character)
        {
            try
            {
                MongoDataBase.charactersCollection.InsertOne(new BaseCharacterrDb
                {
                    Name = character.Name,
                    SkillPoint = character.SkillPoints,
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

        public bool UpdateInventory(string characterId, BaseCharacteristics character)
        {
            try
            {
                var filter = Builders<BaseCharacterrDb>.Filter.Eq(x => 
                                                            x.Id,characterId);
                var updateDefinition =
                    Builders<BaseCharacterrDb>.Update.Set(x => 
                                             x.Inventory, character.Inventory);
                MongoDataBase.charactersCollection.UpdateOne(filter, updateDefinition);
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
                MongoDataBase.charactersCollection.ReplaceOne(x => x.Id == characterId,
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
                    Abilities = character.Abilities,
                    SkillPoint = character.SkillPoints
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
                var characters = MongoDataBase.charactersCollection.Find(new BsonDocument()).ToList();

                foreach (var character in characters)
                {
                    res.Add(new CharacterIdName(character.Experience)
                    {
                        Id = character.Id,
                        Name = character.Name,
                        ClassName = character.CharacterClassName
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
                var characterDb = MongoDataBase.charactersCollection.Find(x => x.Id == characterId).FirstOrDefault();

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
                baseCharacter.SkillPoints = characterDb.SkillPoint;
                baseCharacter.Dexterity.Value = characterDb.Dexterity;
                baseCharacter.Intelligence.Value = characterDb.Intelligence;
                baseCharacter.Strength.Value = characterDb.Strength;
                baseCharacter.Constitution.Value = characterDb.Constitution;
                baseCharacter.Lvl.CurrentExp = characterDb.Experience;
                baseCharacter.Inventory = characterDb.Inventory is not null ? characterDb.Inventory : new List<Item>();
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