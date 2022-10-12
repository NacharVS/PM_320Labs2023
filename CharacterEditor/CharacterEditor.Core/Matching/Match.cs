using CharacterEditor.Core.Db;

namespace CharacterEditor.Core.Matching;

public class Match
{
    private const int MaximumLevelDifference = 2;
    private const int MaximumBalanceAttempts = 50;
    private readonly ICharacterRepository? _repository;

    public Team TeamA { get; }
    public Team TeamB { get; }
    public DateTime DateStarted { get; } = DateTime.Now;

    public bool AreTeamsBalanced => TeamsBalanced();
    public bool AreTeamsReady => TeamsReady();

    public Match(ICharacterRepository repository, string teamAName = "",
        string teamBName = "") : this(teamAName, teamBName)
    {
        _repository = repository;
    }

    public Match(string teamAName = "", string teamBName = "")
    {
        TeamA = new Team { Name = teamAName };
        TeamB = new Team { Name = teamBName };
    }

    public void AutoGenerateTeams()
    {
        if (_repository is null)
            throw new Exception("Cannot auto generate");

        AutoGenerateTeams(_repository.GetMatchParticipants());
    }

    public void AutoGenerateTeams(IEnumerable<CharacterInfo> characters)
    {
        var heroes = FilterByLevelDifference(characters);

        if (heroes.Length < Team.MaximumParticipants * 2)
            throw new Exception("Not enough players");
        var rnd = new Random();
        var balanceAttempt = 0;
        do
        {
            ClearTeamPlayers();
            rnd.Shuffle(heroes);
            for (int i = 0, j = 1, c = 0;
                 c < Team.MaximumParticipants;
                 ++c, i += 2, j += 2)
            {
                TeamA.AddCharacter(heroes[i]);
                TeamB.AddCharacter(heroes[j]);
            }
            balanceAttempt++;
            if (balanceAttempt == MaximumBalanceAttempts)
                throw new Exception("Could not auto-generate teams");
        } while (!AreTeamsReady);
    }

    private void ClearTeamPlayers()
    {
        TeamA.ClearCharacters();
        TeamB.ClearCharacters();
    }

    private double AveragesDifference =>
        TeamA.Characters.Average(x => x.Level) -
        TeamB.Characters.Average(x => x.Level);

    private bool TeamsBalanced()
    {
        try
        {
            return Math.Abs(AveragesDifference) < MaximumLevelDifference;
        }
        catch
        {
            return false;
        }
    }

    private bool TeamsReady()
    {
        return TeamsBalanced() &&
               TeamA.Characters.Length == Team.MaximumParticipants &&
               TeamB.Characters.Length == Team.MaximumParticipants;
    }

    private CharacterInfo[] FilterByLevelDifference(
        IEnumerable<CharacterInfo> characters)
    {
        var sortedChars = characters.OrderByDescending(x => x.Level).ToArray();

        var map = GenerateDifferenceMap(sortedChars);
        var slices = GetSlices(map);

        var longestSlice = slices.Max(x => x.Count);
        var resultSlice = slices.FirstOrDefault(x => x.Count == longestSlice) ??
                          throw new Exception("Could not generate slices");

        return sortedChars
            .AsSpan()
            .Slice(resultSlice.IndexFrom, resultSlice.Count)
            .ToArray();
    }

    private SliceInfo[] GetSlices(int[] map)
    {
        var slices = new List<SliceInfo>();
        int index = 0;
        for (int i = 0; i < map.Length - 1; ++i)
        {
            if (map[i] - map[i + 1] > MaximumLevelDifference)
            {
                slices.Add(new SliceInfo
                    { IndexFrom = index, IndexTo = i });
                index = i;
            }
        }

        slices.Add(new SliceInfo { IndexFrom = index, IndexTo = map.Length });

        return slices.ToArray();
    }

    private int[] GenerateDifferenceMap(CharacterInfo[] sortedCharacters)
    {
        List<int> map = new() { 0 };
        for (int i = 0; i < sortedCharacters.Length - 1; ++i)
        {
            map.Add(sortedCharacters[i].Level - sortedCharacters[i + 1].Level);
        }

        return map.ToArray();
    }
}