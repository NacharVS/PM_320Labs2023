using DataProvider.Domain.Impl;
using DataProvider.Models;
using Editor.Core.Characters;

namespace DataProvider.Migrations;

public class InitCharacters
{
    public void Up()
    {
        var repository = new CharacterRepository(
            new MongoConnection<CharacterDb>("mongodb://localhost", "Characters", "Equipment"));

        repository.Save(new Rogue(10, 10000, null, "Rogue 1", null));
        repository.Save(new Rogue(10, 5600, null, "Rogue 2", null));
        repository.Save(new Rogue(10, 12500, null, "Rogue 3", null));
        repository.Save(new Rogue(10, 17300, null, "Rogue 4", null));
        repository.Save(new Rogue(10, 2900, null, "Rogue 5", null));
        repository.Save(new Warrior(10, 4400, null, "Warrior 1", null));
        repository.Save(new Warrior(10, 15000, null, "Warrior 2", null));
        repository.Save(new Warrior(10, 13200, null, "Warrior 3", null));
        repository.Save(new Warrior(10, 6300, null, "Warrior 4", null));
        repository.Save(new Warrior(10, 2200, null, "Warrior 5", null));
        repository.Save(new Wizard(10, 15200, null, "Wizard 1", null));
        repository.Save(new Wizard(10, 18900, null, "Wizard 2", null));
        repository.Save(new Wizard(10, 4800, null, "Wizard 3", null));
        repository.Save(new Wizard(10, 7200, null, "Wizard 4", null));
        repository.Save(new Wizard(10, 13333, null, "Wizard 5", null));
        repository.Save(new Rogue(10, 8920, null, "Rogue 6", null));
        repository.Save(new Rogue(10, 20000, null, "Rogue 7", null));
        repository.Save(new Rogue(10, 6200, null, "Rogue 8", null));
        repository.Save(new Rogue(10, 16300, null, "Rogue 9", null));
        repository.Save(new Rogue(10, 12200, null, "Rogue 10", null));
    }
}