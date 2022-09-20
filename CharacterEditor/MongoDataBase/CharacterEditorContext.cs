using CharacterEditorCore;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CharacterEditorMongoDataBase
{
    public class CharacterEditorContext
    {
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
                    Intelligence = character.Intelligence.Value
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
            List<CharacterIdName> res = new List<CharacterIdName>();
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
            catch { }
            return res;
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
                return baseCharacter;
            }
            catch 
            {
                return null;
            }
        }
    }
}