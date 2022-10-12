using CharacterEditor.Core.Matching;

namespace CharacterEditor.Core.Db;

public interface IMatchRepository
{
    public IEnumerable<MatchInfo> GetAllMatchesInfo();
    public Match GetMatch(string id);
    public void SaveMatch(Match match);
}