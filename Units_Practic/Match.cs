using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return $"Macth {date} | {_id}";
        }
    }
}
