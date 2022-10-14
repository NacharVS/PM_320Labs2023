
using CharacterEditorCore.DataBase;

namespace CharacterEditorCore.Match
{
    public class MatchInfo
    {
        public const int TeamCharactersCount = 6;
        private const int MaxLvlDif = 2;
        private readonly IMatchRep _matchInfoContext;
        private readonly ICharacterRep _charContext;

        public string Id { get; set; }
        private List<CharacterIdName> _firstTeam;
        public List<CharacterIdName> FirstTeam
        {
            get => _firstTeam;
            set
            {
                foreach (var character in value)
                {
                    AddToTeam(_firstTeam, character);
                }
            }
        }

        private List<CharacterIdName> _secondTeam;
        public List<CharacterIdName> SecondTeam
        {
            get => _secondTeam;
            set
            {
                foreach (var character in value)
                {
                    AddToTeam(_secondTeam, character);
                }
            }
        }

        public DateTime Time { get; set;}

        public MatchInfo(IMatchRep matchInfoContext, ICharacterRep characterRep)
        {
            _matchInfoContext = matchInfoContext;
            _charContext = characterRep;

            _firstTeam = new();
            _secondTeam = new();
        }
        public MatchInfo()
        {
            _firstTeam = new();
            _secondTeam = new();
        }


        public void AddToTeam(List<CharacterIdName> team, 
                                CharacterIdName character)
        {
            team.Add(character);
        }

        public void AutoGenerate()
        {
            if(_matchInfoContext is null)
            {
                return;
            }

            var characters = LvlDifFiltration(
                _charContext.GetAllChars());

            if(characters.Length < TeamCharactersCount * 2)
            {
                throw new Exception("Not enough characters!");
            }

            if(_firstTeam is null)
            {
                _firstTeam = new List<CharacterIdName>();
            }
            else
            {
                _firstTeam.Clear();
            }

            if (_secondTeam is null)
            {
                _secondTeam = new List<CharacterIdName>();
            }
            else
            {
                _secondTeam.Clear();
            }

            for (int i = 0, j = 1, c = 0; c < TeamCharactersCount; ++c, 
                                                            i+= 2, j+=2)
            {
                AddToTeam(_firstTeam,characters[i]);
                AddToTeam(_secondTeam,characters[j]);
            }
        }

        private CharacterIdName[] LvlDifFiltration(
            IEnumerable<CharacterIdName> characters)
        {
            var sortedCharacters = characters.OrderByDescending(z => 
                                                            z.Level).ToArray();

            var lvlDifferences = GetLvlDifferences(sortedCharacters);

            var sections = GetCharSections(lvlDifferences);

            var longestSection = sections.Max(z => z.Count);
            var resSection = sections.FirstOrDefault(z =>
                                                    z.Count == longestSection);

            if(resSection is null)
            {
                throw new Exception("Not right sections!");
            }

            return sortedCharacters
                    .AsSpan()
                    .Slice(resSection.SectionStartIndex,
                                                resSection.Count)
                    .ToArray();
        }

        private int[] GetLvlDifferences(CharacterIdName[] sortedCharacters)
        {
            List<int> lvlDifferences = new() { 0 };

            for (int i = 0; i < sortedCharacters.Length - 1; ++i)
            {
                lvlDifferences.Add(sortedCharacters[i].Level 
                            - sortedCharacters[i + 1].Level);
            }

            return lvlDifferences.ToArray();
        }

        private Section[] GetCharSections(int[] lvlDifferences)
        {
            List<Section> sections = new();

            int ind = 0;

            for (int i = 0; i < lvlDifferences.Length - 1; ++i)
            {
                if (lvlDifferences[i] - lvlDifferences[i+1] > MaxLvlDif)
                {
                    sections.Add(new Section { SectionStartIndex = ind,
                                                        SectionEndIndex = i });
                    ind = i;
                }
            }

            sections.Add(new Section { SectionStartIndex = ind,
                                SectionEndIndex = lvlDifferences.Length });

            return sections.ToArray();
        }

        public bool TeamsBlanceCheck()
        {
            var d = GetAveragesDifference();
            return Math.Abs(d) < MaxLvlDif;
        }

        private double GetAveragesDifference()
        {
            if(FirstTeam.Count == 0 || SecondTeam.Count == 0)
            {
                return 1000;
            }
            return FirstTeam.Average(z => z.Level)
                - SecondTeam.Average(z => z.Level);
        }

        public void StartMatch()
        {
            Time = DateTime.Now;
        }
    }
}
