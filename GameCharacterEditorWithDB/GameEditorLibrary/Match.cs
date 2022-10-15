using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEditorLibrary
{
    public class Match
    {
        [BsonIgnoreIfDefault]
        public ObjectId _id;
        public int number;
        public DateTime dateTime;
        public List<string> firstTeam;
        public List<string> secondTeam;

        public Match(string num)
        {
            dateTime = DateTime.Now;
            number = Convert.ToInt32(num);
            firstTeam = new List<string>();
            secondTeam = new List<string>();
        }
    }
}
