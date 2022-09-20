using CharacterEditorCore;
using MongoDB.Driver;

namespace CharacterEditorMongoDb
{
    public class CharacterRepository
    {
        private IMongoCollection<CharacterDb> _characters;

        public CharacterRepository(string? connectionClient, string? databaseStr)
        {

            var client = new MongoClient(connectionClient);
            var database = client.GetDatabase(databaseStr);

            _characters = database.GetCollection<CharacterDb>("Characters");
        }

        public List<string> GetCharacterNames()
        {
            var res = _characters.Find<CharacterDb>(x => x.Name != null).ToEnumerable<CharacterDb>();
            return res.Select(x => x.Name).ToList<string>();
        }

        public void InsertCharacter(Character character)
        {
            _characters.InsertOne(new CharacterDb(character.Name,
                                                  character.GetType().Name,
                                                  character.GetStrengthValue(),
                                                  character.GetDexterityValue(),
                                                  character.GetConstitutionValue(),
                                                  character.GetIntellisenseValue()));
        }
    }
}
