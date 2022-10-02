namespace CharacterCreator.Core;

public class LevelInfo
{
    private const int NextLvlExpScale = 1000;
    private int _nextLevelExp = 1000;
    public int NextLevelExp => _nextLevelExp;

    private int _currentLvl = 1;

    public int CurrentLvl
    {
        get => _currentLvl;
        set
        {
            _currentLvl = value;
            LevelUpEvent?.Invoke();
        }
    }
    
    private int _currentExperience;
    public int CurrentExperience
    {
        get => _currentExperience;
        set
        {
            while (value >= _nextLevelExp)
            {
                ++CurrentLvl;
                value -= _nextLevelExp;
                _nextLevelExp += NextLvlExpScale * _currentLvl;
            }

            _currentExperience = value;
        }
    }

    public int TotalExperience => GetTotalExperience();

    public int GetTotalExperience()
    {
        int totalExp = 0;
        int level = 1;
        int nextLevelExp = NextLvlExpScale;
        while (level < _currentLvl)
        {
            totalExp += nextLevelExp;
            ++level;
            nextLevelExp += NextLvlExpScale * level;
        }

        return totalExp + _currentExperience;
    }

    public delegate void LevelUpDelegate();

    public event LevelUpDelegate? LevelUpEvent;
}