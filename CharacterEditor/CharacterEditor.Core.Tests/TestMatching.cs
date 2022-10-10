using CharacterEditor.Core.Characteristics;
using CharacterEditor.Core.Classes;
using CharacterEditor.Core.Matching;

namespace CharacterEditor.Core.Tests;

public class TestMatching
{
    const int Level3 = 1000 + 3000;
    const int Level5 = Level3 + 10000 + 15000;
    const int Level7 = Level5 + 21000 + 28000;
    const int Level10 = Level7 + 36000 + 45000 + 55000;

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
        }.Select(x => new ShortCharacter(x.Level.TotalExperience)).ToArray();

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
        Assert.Pass($"{nameof(TestAutoGeneration)} passed");
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
        }.Select(x => new ShortCharacter(x.Level.TotalExperience)).ToArray();

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
        Assert.Pass($"{nameof(TestAutoGenerationWithHighLevels)} passed");
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
        }.Select(x => new ShortCharacter(x.Level.TotalExperience)).ToArray();

        var match = new Match();
        Assert.Throws<Exception>(() => match.AutoGenerateTeams(chars));
        Assert.Pass($"{nameof(TestAutoGenerationWithHighLevelsShouldFail)} passed");
    }

    [Test]
    public void TestAutoGenerationWithoutRepositoryShouldThrowException()
    {
        var match = new Match();
        Assert.Throws<Exception>(() => match.AutoGenerateTeams(),
            "Autogenerate may give incorrect answer");
        Assert.Pass(
            $"{nameof(TestAutoGenerationWithoutRepositoryShouldThrowException)} passed");
    }
}