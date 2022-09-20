﻿using System;
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
            var database = client.GetDatabase("Example320");
            var collection = database.GetCollection<Unit>("ExCogHk");
            collection.InsertOne(unit);
        }

        public static Unit FindByName(string name)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("Example320");
            var collection = database.GetCollection<Unit>("ExCogHk");
            Console.WriteLine(name);
            var unit = collection.Find(x => x.Name == name).FirstOrDefault();
            return unit;
        }

        public static List<Unit> ImportData()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("Example320");
            var collection = database.GetCollection<Unit>("ExCogHk");
            var list = collection.Find(new BsonDocument()).ToList();
            return list;
        }
    }
}