using MongoDB.Driver;

namespace CharacterEditorMongoDb
{
    public class DBConnection
    {
        public IMongoDatabase Connection { get; private set; }

        public DBConnection(string? connectionClient, string? databaseStr)
        {
            var client = new MongoClient(connectionClient);
            Connection = client.GetDatabase(databaseStr);
        }
    }
}