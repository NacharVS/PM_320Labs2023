using DataProvider.Domain.Impl;
using DataProvider.Models;
using Editor.Core.Abilities;

namespace DataProvider.Migrations;

public class InitAbilities
{
    public void Up()
    {
        var repository = new AbilityRepository(
            new MongoConnection<AbilityDb>("mongodb://localhost", "Characters", "Abilities"));

        repository.Save(new Ability("Upgrade Health", 3));
        repository.Save(new Ability("Upgrade Physical Defense", 3));
        repository.Save(new Ability("Stone skin", 3));
        repository.Save(new Ability("Iron fists", 6));
        repository.Save(new Ability("Genius brain", 6));
        repository.Save(new Ability("Holy arms", 9));
        repository.Save(new Ability("Double Upgrade Health", 9));
        repository.Save(new Ability("Double Upgrade Physical Defense", 3));
        repository.Save(new Ability("Daedra skin", 12));
        repository.Save(new Ability("Valkyrie bless", 12));
    }
}

