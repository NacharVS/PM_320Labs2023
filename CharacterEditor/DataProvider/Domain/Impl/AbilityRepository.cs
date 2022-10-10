using DataProvider.Models;
using Editor.Core;
using Editor.Core.Abilities;
using Editor.Core.Characters;
using MongoDB.Driver;

namespace DataProvider.Domain.Impl;

public class AbilityRepository : BaseRepository<Ability, AbilityDb>
{
    private Dictionary<string, Action<Character>> _abilityActions;

    public AbilityRepository(MongoConnection<AbilityDb> connection) : base(connection)
    {
        InitializeAbilityActions();
        //FirstTimeSetup();
    }

    protected override Ability? InitializeEntity(AbilityDb model)
    {
        return CastToEntity(model);
    }

    protected override Ability? CastToEntity(AbilityDb model)
    {
        if (model.Name != null) 
            return new Ability(model.Name, model.RequiredLevel, _abilityActions[model.Name]);
        return null;
    }
    
    private void FirstTimeSetup()
    {
        Save(new Ability("Upgrade Health", 3));
        Save(new Ability("Upgrade Physical Defense", 3));
        Save(new Ability("Stone skin", 3));
        Save(new Ability("Iron fists", 6));
        Save(new Ability("Genius brain", 6));
        Save(new Ability("Holy arms", 9));
        Save(new Ability("Double Upgrade Health", 9));
        Save(new Ability("Double Upgrade Physical Defense", 3));
        Save(new Ability("Daedra skin", 12));
        Save(new Ability("Valkyrie bless", 12));
    }

    /// <summary>
    /// Дикий костыль за невозможностью хранить делегаты в монго
    /// </summary>
    private void InitializeAbilityActions()
    {
        _abilityActions = new Dictionary<string, Action<Character>>
        {
            {"Upgrade Health", x => x.HealthPoints += 15},
            {"Upgrade Physical Defense", x => x.PhysicalDefense += 10},
            {"Stone skin", x => x.PhysicalDefense += 25},
            {"Iron fists", x => x.PhysicalDamage += 25},
            {"Genius brain", x => x.MagicDamage += 18},
            {"Holy arms", x => x.MagicDamage += 35},
            {"Double Upgrade Health", x => x.HealthPoints += 35},
            {"Double Upgrade Physical Defense", x => x.PhysicalDefense += 35},
            {"Daedra skin", x => x.PhysicalDefense += 55},
            {"Valkyrie bless", x => x.MagicDamage += 55}
        };
    }
}