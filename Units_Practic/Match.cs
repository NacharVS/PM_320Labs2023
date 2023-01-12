using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Units_Practic
{
    public class Match
    {
        public ObjectId _id;

        public DateTime date;

        [BsonIgnoreIfDefault]
        public List<ObjectId> firstTeam;


        [BsonIgnoreIfDefault]
        public List<ObjectId> secondTeam;

        public Match()
        {
            firstTeam = new List<ObjectId>();
            secondTeam = new List<ObjectId>();
        }

        public override string ToString()
        {
            return $"Macth: {GetUnitsName(firstTeam)} VS {GetUnitsName(secondTeam)}. On {date}.";
        }

        private string GetUnitsName(List<ObjectId> team)
        {
            StringBuilder names = new();

            foreach (var id in team)
            {
                try
                {
                    names.Append(MongoDb.MongoDb.FindById(id.ToString()).name);
                }
                catch
                {
                    names.Append("*unit is lost*");
                }

                names.Append(", ");
            }
            names.Remove(names.Length-2, 2);

            return names.ToString();
        }
    }
}
