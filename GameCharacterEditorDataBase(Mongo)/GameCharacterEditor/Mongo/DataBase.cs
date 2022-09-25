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

        public static string FindByName(string name)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("GameCharacterEditor");
            var collection = database.GetCollection<Character>("CharacterCollection");
            var character = collection.Find(x => x.Name == name).FirstOrDefault();

            return $"{character?.Name} {character?.Strength} {character?.Dexterity} {character?.Constitution} {character?.Intelligence} {character?.HP} {character?.MP} {character?.PDef} {character?.Attack} {character?.MPAttack}";
        }
    }
}
