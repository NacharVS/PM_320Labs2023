using CharacterEditor.Core.Db;
using CharacterEditor.Core.Exceptions;
using CharacterEditor.Core.Matching;
using MongoDB.Driver;

namespace CharacterEditor.MongoDB;

public class MatchRepository : IMatchRepository
{
    private IMongoCollection<MatchDb> Matches { get; }

    public MatchRepository(MongoConnection connection)
    {
        Matches = connection.Database?.GetCollection<MatchDb>("Matches")!;
    }

    public IEnumerable<MatchInfo> GetAllMatchesInfo()
    {
        return Matches.Find(x => true)
            .ToEnumerable()
            .Select(x => new MatchInfo
            {
                Id = x.Id, DateStarted = x.DateStarted
            });
    }

    public Match GetMatch(string id)
    {
        var match = Matches.Find(x => x.Id == id).FirstOrDefault() ??
                    throw new NotFoundException();
        return new Match
        {
            Id = match.Id, TeamA = match.TeamA, TeamB = match.TeamB,
            DateStarted = match.DateStarted
        };
    }

    public void SaveMatch(Match match)
    {
        Matches.InsertOne(new MatchDb
        {
            DateStarted = match.DateStarted, TeamA = match.TeamA,
            TeamB = match.TeamB
        });
    }
}