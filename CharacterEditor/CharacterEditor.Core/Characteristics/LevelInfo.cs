namespace CharacterEditor.Core.Characteristics;

public class LevelInfo
{
    private const int FirstLevelExp = 1000;
    private const int ExpScalePerLevel = 1000;

    private int _currentLevel = 1;
    public int CurrentLevel => _currentLevel;

    private int _currentExperience;

    public int CurrentExperience
    {
        get => _currentExperience;
        set
        {
            var currLevelExp = GetCurrentLevelExp();
            while (value >= currLevelExp)
            {
                _currentLevel++;
                value -= currLevelExp;
                _currentExperience = value;
                TotalExperience += currLevelExp;
                currLevelExp = GetCurrentLevelExp();
                OnLevelUp?.Invoke();
            }

            TotalExperience += value - _currentExperience;
            _currentExperience = value;
        }
    }

    private int _totalExperience;

    public int TotalExperience
    {
        get => _totalExperience;
        private set => _totalExperience = value;
    }

    public int ExperienceToGainLevel =>
        GetCurrentLevelExp();

    public int ExperienceLeft => ExperienceToGainLevel - CurrentExperience;

    private int GetCurrentLevelExp()
    {
        var res = FirstLevelExp;
        var xpToLevelUp = ExpScalePerLevel;
        var currentLevel = CurrentLevel;
        while (currentLevel > 1)
        {
            xpToLevelUp += ExpScalePerLevel;
            res += xpToLevelUp;
            currentLevel--;
        }

        return res;
    }

    public event LevelUpEventHandler? OnLevelUp;
}

public delegate void LevelUpEventHandler();