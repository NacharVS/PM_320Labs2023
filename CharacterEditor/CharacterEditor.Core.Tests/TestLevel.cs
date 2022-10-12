using CharacterEditor.Core.Characteristics;

namespace CharacterEditor.Core.Tests;

public class TestLevel
{
    [Test]
    public void TestLevelFromExpConstructor()
    {
        const int expToGain = 6000;
        const int expectedResult = 3;

        LevelInfo levelInfo = new LevelInfo(expToGain);

        Assert.That(levelInfo.CurrentLevel, Is.EqualTo(expectedResult),
            "Level value is bad");
        Assert.Pass();
    }

    [Test]
    public void TestLevelTotalExperience()
    {
        const int repeatCount = 5;
        const int expPortion = 2000;
        const int expectedResult = expPortion * repeatCount;

        LevelInfo levelInfo = new LevelInfo();

        for (int i = 0; i < repeatCount; ++i)
        {
            levelInfo.CurrentExperience += expPortion;
            Assert.That(levelInfo.TotalExperience,
                Is.EqualTo(expPortion * (i + 1)), "Wrong xp count");
        }

        Assert.That(levelInfo.TotalExperience, Is.EqualTo(expectedResult),
            "Wrong xp count");
        Assert.Pass();
    }

    [Test]
    public void TestLevelXpCount()
    {
        const int level = 5;
        const int expectedResult = 1000 + 2000 + 3000 + 4000 + 5000;

        var res = LevelInfo.GetLevelXp(level);

        Assert.That(res, Is.EqualTo(expectedResult), "Wrong xp counted");
        Assert.Pass();
    }

    [Test]
    public void TestLevelXpCountByAdding()
    {
        const int experienceToGain = 1000 + 3000 + 10000 + 15000 + 21000;
        const int expectedResult = 6;

        var levelInfo = new LevelInfo();
        levelInfo.CurrentExperience += experienceToGain;

        Assert.That(levelInfo.CurrentLevel, Is.EqualTo(expectedResult),
            "Wrong xp counted");
        Assert.Pass();
    }
}