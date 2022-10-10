namespace CharacterEditor.Core.Characteristics;

/// <summary>
/// Class that contains all levelling logic
/// </summary>
public class LevelInfo
{
    private const int FirstLevelExp = 1000;
    private const int ExpScalePerLevel = 1000;

    private int _currentLevel = 1;

    /// <summary>
    /// Current character's level
    /// </summary>
    public int CurrentLevel => _currentLevel;

    private int _currentExperience;

    /// <summary>
    /// Current level experience
    /// </summary>
    public int CurrentExperience
    {
        get => _currentExperience;
        set
        {
            TotalExperience += value - _currentExperience;
            var currLevelExp = GetCurrentLevelExp();
            while (value >= currLevelExp)
            {
                _currentLevel++;
                value -= currLevelExp;
                _currentExperience = value;
                currLevelExp = GetCurrentLevelExp();
                OnLevelUp?.Invoke();
            }

            _currentExperience = value;
        }
    }

    /// <summary>
    /// Total experience gained
    /// </summary>
    public int TotalExperience { get; private set; }

    /// <summary>
    /// Experience needed to level up
    /// </summary>
    public int ExperienceToGainLevel =>
        GetCurrentLevelExp();

    /// <summary>
    /// Experience character needs to gain to level up
    /// </summary>
    public int ExperienceLeft => ExperienceToGainLevel - CurrentExperience;

    public static int GetLevelXp(int level)
    {
        var res = FirstLevelExp;
        var xpToLevelUp = ExpScalePerLevel;
        var currentLevel = level;
        while (currentLevel > 1)
        {
            xpToLevelUp += ExpScalePerLevel;
            res += xpToLevelUp;
            currentLevel--;
        }

        return res;
    }

    private int GetCurrentLevelExp()
    {
        return GetLevelXp(CurrentLevel);
    }

    public LevelInfo(int totalExperience = 0)
    {
        CurrentExperience += totalExperience;
    }

    public event LevelUpEventHandler? OnLevelUp;
}

public delegate void LevelUpEventHandler();