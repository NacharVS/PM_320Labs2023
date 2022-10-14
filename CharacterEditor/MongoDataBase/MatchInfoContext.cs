
using CharacterEditorCore;
using CharacterEditorCore.DataBase;
using CharacterEditorCore.Match;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CharacterEditorMongoDataBase
{
    public class MatchInfoContext : IMatchRep
    {
        public MatchInfo GetMatch(string Id)
        {
            try
            {
                MatchInfo match = null;
                var matchInDb = MongoDataBase.matchCollection.Find(x => x.Id == Id).FirstOrDefault();

                if (matchInDb is null)
                {
                    return null;
                }
                return new MatchInfo
                {
                    Id = matchInDb.Id,
                    FirstTeam = matchInDb.FirstTeam is not null ? matchInDb.FirstTeam : new List<CharacterIdName>(),
                    SecondTeam = matchInDb.SecondTeam is not null ? matchInDb.SecondTeam : new List<CharacterIdName>(),
                    Time = matchInDb.Time
                };
            }
            catch
            {
                return null;
            }
        }

        public List<MatchInfo> GetAllMatches()
        {
            List<MatchInfo> res = new();
            try
            {
                var matches = MongoDataBase.matchCollection.Find(new BsonDocument()).ToList();

                foreach (var match in matches)
                {
                    res.Add(new MatchInfo
                    {
                        Id = match.Id,
                        FirstTeam = match.FirstTeam,
                        SecondTeam = match.SecondTeam,
                        Time= match.Time
                    });
                }
                return res;
            }
            catch
            {
                return res;
            }
        }

        public bool SaveMatch(MatchInfo match)
        {
            try
            {
                MongoDataBase.matchCollection.InsertOne(new MatchInfoDb
                {
                    FirstTeam = match.FirstTeam,
                    SecondTeam = match.SecondTeam,
                    Time = DateTime.Now
                }
                );
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
