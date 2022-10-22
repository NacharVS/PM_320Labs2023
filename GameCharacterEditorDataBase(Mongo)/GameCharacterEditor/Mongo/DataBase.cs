using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GameCharacterEditor
{
    class DataBase
    {
        //Character
        public static void AddCharacterToDataBase(Character character)
        {
            MongoClient client = new MongoClient("mongodb://localhost");
            IMongoDatabase database = client.GetDatabase("GameCharacterEditor");
            var collection = database.GetCollection<Character>("CharacterCollection");
            collection.InsertOne(character);
        }

        public static Character FindCharacterByName(string name)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("GameCharacterEditor");
            var collection = database.GetCollection<Character>("CharacterCollection");
            var character = collection.Find(x => x.Name == name).FirstOrDefault();

            return character;
        }

        public static List<Character> ImportCharacterDataBase()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("GameCharacterEditor");
            var collection = database.GetCollection<Character>("CharacterCollection");
            var list = collection.Find(new BsonDocument()).ToList();

            return list;
        }

        public static void ReplaceCharacterByName(string name, Character character)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("GameCharacterEditor");
            var collection = database.GetCollection<Character>("CharacterCollection");
            collection.ReplaceOne(x => x.Name == name, character);
        }

        public static void UpdateCharacterByName(string name, Character character)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("GameCharacterEditor");
            var collection = database.GetCollection<Character>("CharacterCollection");
            var updateDefenition = Builders<Character>.Update.Set(x => x.chainmail, character.chainmail)
                .Set(x => x.helmet, character.helmet)
                .Set(x => x.shild, character.shild);
            collection.UpdateOne(x => x.Name == name, updateDefenition);
        }

        //Match
        public static void AddMatchToDataBase(Match match)
        {
            MongoClient client = new MongoClient("mongodb://localhost");
            IMongoDatabase database = client.GetDatabase("Matches");
            var collection = database.GetCollection<Match>("TeamsCollection");
            collection.InsertOne(match);
        }

        public static Match FindMatchByNumber(int number)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Matches");
            var collection = database.GetCollection<Match>("TeamsCollection");
            var character = collection.Find(x => x.NumberMatch == number).FirstOrDefault();

            return character;
        }

        public static List<Match> ImportMatchDataBase()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Matches");
            var collection = database.GetCollection<Match>("TeamsCollection");
            var list = collection.Find(new BsonDocument()).ToList();

            return list;
        }
    }
}
