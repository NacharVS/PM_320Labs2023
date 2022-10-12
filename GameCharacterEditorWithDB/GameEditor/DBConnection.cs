using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using GameEditorLibrary;

namespace GameEditor
{
    public class DBConnection
    {
        public static void AddToDataBase(Unit unit)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("Galieva");
            var collection = database.GetCollection<Unit>("CollectionOfUnits");
            collection.InsertOne(unit);
        }

        public static void AddMatchToDataBase(Match match)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("Galieva");
            var collection = database.GetCollection<Match>("CollectionOfMatches");
            collection.InsertOne(match);
        }

        public static Unit FindByName(string name)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("Galieva");
            var collection = database.GetCollection<Unit>("CollectionOfUnits");
            var pr = Builders<Unit>.Projection.
            Exclude("phDefention").
            Exclude("MP").
            Exclude("HP").
            Exclude("manaAttack").
            Exclude("manaPoints").
            Exclude("attackDamage");
            var unit = collection.Find(x => x.Name == name).Project<Unit>(pr).FirstOrDefault();
            return unit;
        }

        public static List<Unit> ImportData()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("Galieva");
            var collection = database.GetCollection<Unit>("CollectionOfUnits");
            var list = collection.Find(new BsonDocument()).ToList();
            return list;
        }

        public static void Replace(Unit unit)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("Galieva");
            var filter = new BsonDocument("_id", unit._id);
            var collection = database.GetCollection<Unit>("CollectionOfUnits");
            collection.ReplaceOne(filter, unit);
        }

        public static void Update(Unit unit)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("Galieva");
            var filter = new BsonDocument("_id", unit._id);
            var collection = database.GetCollection<Unit>("CollectionOfUnits");
            var update = Builders<Unit>.Update.Set(x => x.helmet, unit.helmet)
                                                   .Set(x => x.chestplate, unit.chestplate)
                                                   .Set(x => x.boots, unit.boots);
            collection.UpdateOne(filter, update);
        }
    }
}