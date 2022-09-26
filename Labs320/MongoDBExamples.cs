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

        public static void FindByName(string name)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Example320");
            var collection = database.GetCollection<Unit>("ExCollection");
            var unit = collection.Find(x => x.Name == name).FirstOrDefault();

                Console.WriteLine($"{unit?.Name} {unit?.Age} {unit?._id} {unit?.DriverCard}");

        }

        public static void ReplaceByName(string name, Unit unit)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Example320");
            var collection = database.GetCollection<Unit>("ExCollection");
            //var filter = Builders<Unit>.Update.Set(name == "Jimmy")
            collection.ReplaceOne(x => x.Name == name, unit);

        }
    }
}
