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
        public List<string> firstTeam;
        public List<string> secondTeam;

        public Match()
        {
            firstTeam = new List<string>();
            secondTeam = new List<string>();
        }
    }
}
