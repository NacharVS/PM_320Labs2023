using CharacterEditor.Core.Classes;
using CharacterEditor.Core.Matching;

namespace CharacterEditor.Core.Tests;

public class TestMatching
{
    private const int Level2 = 1000;
    private const int Level3 = Level2 + 3000;
    private const int Level4 = Level3 + 10000;
    private const int Level5 = Level4 + 15000;
    private const int Level6 = Level5 + 21000;
    private const int Level7 = Level6 + 28000;
    private const int Level8 = Level7 + 36000;
    private const int Level9 = Level8 + 45000;
    private const int Level10 = Level9 + 55000;
    private const int Level11 = Level10 + 66000;
    private const int Level12 = Level11 + 78000;

    [Test]
    public void TestManyLevels()
    {
        var chars = new CharacterInfo[]
        {
            new(Level2), new(Level3), new(Level4), new(Level5),
            new(Level6), new(Level7), new(Level8), new(Level9),
            new(Level10), new(Level11), new(Level12), new(), new(Level6),
            new (Level7)
        };

        var match = new Match();
        match.AutoGenerateTeams(chars);
        
        Assert.That(match.AreTeamsReady, Is.True);
        Assert.Pass();
    }

    [Test]
    public void TestAutoGeneration()
    {
        var chars = new CharacterBase[]
        {
            new Rogue(Level3), new Rogue(Level5), new Warrior(Level5),
            new Wizard(Level7),
            new Wizard(Level7), new Warrior(Level5), new Wizard(Level7),
            new Rogue(Level5), new Warrior(Level5), new Wizard(Level7),
            new Wizard(Level7), new Warrior(Level5), new Wizard(Level7)
        }.Select(x => new CharacterInfo(x.Level.TotalExperience)).ToArray();

        var match = new Match();
        match.AutoGenerateTeams(chars);

        Assert.That(match.TeamA.Characters.Length,
            Is.EqualTo(Team.MaximumParticipants),
            "Not enough participants generated");
        Assert.That(match.TeamB.Characters.Length,
            Is.EqualTo(Team.MaximumParticipants),
            "Not enough participants generated");
        Assert.False(match.TeamA.Characters.Contains(chars[0]),
            "Wrong character added");
        Assert.False(match.TeamA.Characters.Contains(chars[0]),
            "Wrong character added");
        Assert.Pass();
    }

    [Test]
    public void TestAutoGenerationWithHighLevels()
    {
        var chars = new CharacterBase[]
        {
            new Rogue(Level3), new Rogue(Level5), new Warrior(Level5),
            new Wizard(Level7),
            new Wizard(Level7), new Warrior(Level5), new Wizard(Level7),
            new Rogue(Level5), new Warrior(Level5), new Wizard(Level7),
            new Wizard(Level7), new Warrior(Level5), new Wizard(Level7),
            new Warrior(Level10), new Wizard(Level10)
        }.Select(x => new CharacterInfo(x.Level.TotalExperience)).ToArray();

        var match = new Match();
        match.AutoGenerateTeams(chars);

        Assert.That(match.TeamA.Characters.Length,
            Is.EqualTo(Team.MaximumParticipants),
            "Not enough participants generated");
        Assert.That(match.TeamB.Characters.Length,
            Is.EqualTo(Team.MaximumParticipants),
            "Not enough participants generated");
        Assert.False(match.TeamA.Characters.Contains(chars[^1]),
            "Wrong character added");
        Assert.False(match.TeamA.Characters.Contains(chars[^1]),
            "Wrong character added");
        Assert.Pass();
    }

    [Test]
    public void TestAutoGenerationWithHighLevelsShouldFail()
    {
        var chars = new CharacterBase[]
        {
            new Rogue(Level3), new Rogue(Level5), new Warrior(Level5),
            new Wizard(Level5), new Wizard(Level5), new Wizard(Level5),
            new Wizard(Level5), new Wizard(Level5), new Wizard(Level5),
            new Warrior(Level10), new Wizard(Level10), new Warrior(Level10)
        }.Select(x => new CharacterInfo(x.Level.TotalExperience)).ToArray();

        var match = new Match();
        Assert.Throws<Exception>(() => match.AutoGenerateTeams(chars));
        Assert.Pass();
    }

    [Test]
    public void TestAutoGenerationWithoutRepositoryShouldThrowException()
    {
        var match = new Match();
        Assert.Throws<Exception>(() => match.AutoGenerateTeams(),
            "Autogenerate may give incorrect answer");
        Assert.Pass();
    }
}