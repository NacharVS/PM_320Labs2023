using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CreateCharacterWarcraftWpf
{
    public static class Mongo
    {
        public static IMongoDatabase db = new MongoClient("mongodb://localhost").GetDatabase("GilaevWarcraft320");

        public static void AddToDataBase(Character unit)
        {
            var collection = db.GetCollection<Character>("ExCollection");
            collection.InsertOne(unit);
        }

        public static void FindByName(string name)
        {
            var collection = db.GetCollection<Character>("ExCollection");
            var unit = collection.Find(x => x.name == name).FirstOrDefault();
        }

        public static IMongoCollection<Character> GetCollection()
        {
            var filter = new BsonDocument();
            var collection = db.GetCollection<Character>("ExCollection");

            return collection;
        }
    }
    
}
