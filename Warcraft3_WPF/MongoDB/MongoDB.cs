using CharacterEditorCore;
using MongoDB.Driver;

namespace MongoDB
{
    public class MongoDB
    {
        private IMongoCollection<CharacterDb> characters;

        public MongoDB()
        {
            MongoClient client = new MongoClient("mongodb://localhost:27017");
            var dataBase = client.GetDatabase("CharacterEditDB");
            characters = dataBase.GetCollection<CharacterDb>("Characters");
        }

        public void InsertUnit(Character character)
        {
            var characterDb = new CharacterDb(character.Name, character.GetType().Name,
                character.GetStrengthValue(), character.GetDexterityValue(), character.GetConstitutionValue(),
                character.GetIntellisenseValue());
            characters.InsertOne(characterDb);
        }
    }
}