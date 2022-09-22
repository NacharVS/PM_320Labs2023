using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GameCharacterEditor
{
    class DataBase
    {
        public static void AddToDataBase(Character unit)
        {
            MongoClient client = new MongoClient("mongodb://localhost");
            IMongoDatabase database = client.GetDatabase("GameCharacterEditor");
            var collection = database.GetCollection<Character>("CharacterCollection");
            collection.InsertOne(unit);
        }
    }
}
