using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CreateCharacterWarcraftWpf
{
    public static class MongoMatch
    {
        public static IMongoDatabase dbb = new MongoClient("mongodb://localhost").GetDatabase("GilaevWarcraftMatch320");

        public static void AddToDataBase(TeamMatch teamMatch)
        {
            var collection = dbb.GetCollection<TeamMatch>("GilaevWarcraftMatch320");
            collection.InsertOne(teamMatch);
        }
    }
    
}
