using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Units_Practic.Characters;

namespace Units_Practic.MongoDb
{
    public class MongoDb
    {
        public static IMongoCollection<Unit> collection = 
            new MongoClient("mongodb://localhost:27017").GetDatabase("Units").GetCollection<Unit>("UnitsCollection");
        
        public static IMongoCollection<Match> matchCollection = 
            new MongoClient("mongodb://localhost:27017").GetDatabase("Units").GetCollection<Match>("MatchCollection");

        public static void AddToDataBase(Unit unit)
        {
            collection.InsertOne(unit);
        }

        public static void AddMatchToDataBase(Match match)
        {
            matchCollection.InsertOne(match);
        }

        public static void DeleteFromDataBase(Unit unit)
        {
            var filter = new BsonDocument("_id", unit._id);
            collection.DeleteOne(filter);
        }

        public static void ReplaceOneInDataBase(Unit unit)
        {
            var filter = new BsonDocument("_id", unit._id);
            collection.ReplaceOne(filter, unit);
        }

        public static Unit FindById(string id)
        {
            var filter = new BsonDocument("_id", ObjectId.Parse(id));
            return collection.Find(filter).FirstOrDefault();
        }

        public static IMongoCollection<Unit> GetCollection()
        {
            return collection;
        }

        public static void Connect_lbUnits()
        {
            var temp = new Warrior();
            AddToDataBase(temp);
            DeleteFromDataBase(temp);
        }
    }
}