using MongoDB.Driver;
using CharacterEditorCore;

namespace CharacterEditorMongoDataBase
{
    public static class MongoDataBase
    {
        private static readonly MongoClient client = new MongoClient("mongodb://localhost");
        internal static readonly IMongoDatabase db = client.GetDatabase("CharacterEditorDb");
        internal static readonly IMongoCollection<BaseCharacterrDb> collection = db.GetCollection<BaseCharacterrDb>("Characters");
    }
}
