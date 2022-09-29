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
        public static void AddToDataBase(Character character)
        {
            MongoClient client = new MongoClient("mongodb://localhost");
            IMongoDatabase database = client.GetDatabase("GameCharacterEditor");
            var collection = database.GetCollection<Character>("CharacterCollection");
            collection.InsertOne(character);
        }

        public static Character FindByName(string name)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("GameCharacterEditor");
            var collection = database.GetCollection<Character>("CharacterCollection");
            var character = collection.Find(x => x.Name == name).FirstOrDefault();

            return character;
        }

        public static List<Character> ImportData()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("GameCharacterEditor");
            var collection = database.GetCollection<Character>("CharacterCollection");
            var list = collection.Find(new BsonDocument()).ToList();

            return list;
        }

        public static void ReplaceByName(string name, Character character)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("GameCharacterEditor");
            var collection = database.GetCollection<Character>("CharacterCollection");
            var filter = new  BsonDocument("Id", character.Id);
            collection.ReplaceOne(filter, character);
        }
    }
}
