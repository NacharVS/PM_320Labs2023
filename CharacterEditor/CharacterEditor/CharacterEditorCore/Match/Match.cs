namespace CharacterEditorCore.Match
{
    public class Match
    {
        private const int MaxLevelDifference = 2;
        public const int CharactersCount = 6;
        public List<MatchCharacterInfo> FirstTeam = new();
        public List<MatchCharacterInfo> SecondTeam = new();
        public DateTime MatchDate;

        private CharacterEditorCore.ICharacterRepository _characterRepository;

        public Match(ICharacterRepository repos)
        {
            _characterRepository = repos;
        }

        public int GetTeamCharactersCount()
        {
            return CharactersCount;
        }

        public bool StartMatch()
        {
            if (IsTeamsBalanced())
            {
                MatchDate = DateTime.Now;
                return true;
            }

            return false;
        }

        public void AddCharacter(List<MatchCharacterInfo> team, 
                                MatchCharacterInfo characterInfo)
        {
            team.Add(characterInfo);
        }

        public void AutoGenerate()
        {
            if (_characterRepository == null)
            {
                return;
            }

            var characters = GetAvailableParticipants();

            if (characters.Length < CharactersCount * 2)
            {
                return;
            }

            FirstTeam = new List<MatchCharacterInfo>();
            SecondTeam = new List<MatchCharacterInfo>();

            for (int f = 0, s = 1, i = 0; i < CharactersCount; i++, f += 2, s +=2)
            {
                FirstTeam.Add(characters[f]);
                SecondTeam.Add(characters[s]);
            }
        }

        private MatchCharacterInfo[] GetAvailableParticipants()
        {
            var sortedList = GetSortedList();
            var differences = GetDifferencesList(sortedList);

            var sections = GetSections(differences);

            var max = sections.Max(x => x.Count);
            var maxSection = sections.FirstOrDefault(x => x.Count == max);

            if (maxSection is null)
            {
                throw new Exception();
            }

            return sortedList.ToArray().AsSpan().Slice(maxSection.IndexFrom, maxSection.Count).ToArray();
        }
        
        private List<MatchCharacterInfo> GetSortedList()
        {
            return _characterRepository.GetAllCharacters().OrderByDescending(x => x.Level).ToList();
        }

        private List<int> GetDifferencesList(List<MatchCharacterInfo> characters)
        {
            var differences = new List<int>();

            for (int i = 0; i < characters.Count - 1; i++)
            {
                differences.Add(Math.Abs(characters[i].Level - characters[i + 1].Level));
            }

            return differences;
        }

        private List<Section> GetSections(List<int> differences)
        {
            int index = 0;
            var sections = new List<Section>();

            for (int i = 0; i < differences.Count - 1; i++)
            {
                if (differences[i] - differences[i + 1] > MaxLevelDifference)
                {
                    sections.Add(new Section() { IndexFrom = index, IndexTo = i });
                    index = i;
                }                
            }

            sections.Add(new Section() { IndexFrom = index, IndexTo = differences.Count });

            return sections;
        }

        public bool IsTeamsBalanced()
        {
            if (FirstTeam == null || SecondTeam == null)
            {
                return false;
            }

            if (FirstTeam.Count == 0 || SecondTeam.Count == 0)
            {
                return false;
            }

            return Math.Abs(FirstTeam.Average(x => x.Level)
                            - SecondTeam.Average(x => x.Level))
                            < MaxLevelDifference;
        }
    }
}