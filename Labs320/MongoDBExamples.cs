using MongoDB.Driver;

namespace Labs320
{
    internal class MongoDBExamples
    {
        public static void AddToDataBase(Unit unit)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Example320");
            var collection = database.GetCollection<Unit>("ExCollection");
            collection.InsertOne(unit);
        }
    }
}
