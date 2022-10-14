using CharacterEditorCore.Match;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace CharacterEditorMongoDb
{
    public class MatchRepository
    {
        public IMongoCollection<MatchDB> _matches;

        public MatchRepository(DBConnection dbConnection)
        {
            _matches = dbConnection.Connection.GetCollection<MatchDB>("Matches");
        }

        public void InsertMatchInfo(Match match)
        {
            _matches.InsertOne(new MatchDB { FirstTeam = match.FirstTeam,
                                            SecondTeam = match.SecondTeam,
                                            StartDate = match.MatchDate});
        }

        public List<MatchDB> GetAllMatches()
        {
            return _matches.Find(x => true).ToList();
        }
    }
}