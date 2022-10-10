using CharacterEditorCore;
namespace CharacterEditorCore.Match
{
    public class MatchInfo
    {
        private List<BaseCharacteristics> _firstTeam;
        public List<BaseCharacteristics> FirstTeam
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

        private List<BaseCharacteristics> _secondTeam;
        public List<BaseCharacteristics> SecondTeam
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

        private void AddToTeam(List<BaseCharacteristics> team, BaseCharacteristics character)
        {
            if (Math.Abs(GetLvlDifference()) <= 2)
            {
                team.Add(character);
            }
        }

        private int GetLvlDifference()
        {
            int teamALvl = 0;
            int teamBLvl = 0;

            foreach(var character in _firstTeam)
            {
                teamALvl += character.Lvl.CurrentLevel;
            }

            foreach (var character in _secondTeam)
            {
                teamBLvl += character.Lvl.CurrentLevel;
            }

            return (teamALvl / _firstTeam.Count) - (teamBLvl/_secondTeam.Count);
        }
    }
}
