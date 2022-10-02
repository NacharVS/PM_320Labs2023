using CharacterCreator.Core;
using CharacterCreator.Data.Interfaces;
using CharacterCreator.Data.Models;
using MongoDB.Driver;

namespace CharacterCreator.Data.Repositories;

public class AbilityRepository : IAbilityRepository
{
    private DbConnection<AbilityDbModel> _dbConnection;

    public AbilityRepository(DbConnection<AbilityDbModel> connection)
    {
        _dbConnection = connection;
    }

    public IEnumerable<Ability> GetAllAbilities()
    {
        return _dbConnection.Collection.Find(x => true).ToEnumerable().Select(x => 
            new Ability(x.Name, x.RequiredLevel, x.HealthChangeValue, x.ManaChangeValue, x.ManaAttackChangeValue, 
                x.PhysAttackChangeValue, x.PhysDefenseChangeValue));
    }

    public void AddDefaultAbilities()
    {
        foreach (Ability ability in CreatedAbilities.abilities)
        {
            if (_dbConnection.Collection.Find(x => x.Name == ability.Name).FirstOrDefault() is not null)
                continue;
            
            _dbConnection.Collection.InsertOne(new AbilityDbModel(ability));
        }
    }

    public Ability GetAbilityByName(string name)
    {
        AbilityDbModel abilityDbModel = _dbConnection.Collection.Find(x => x.Name == name).FirstOrDefault();
        Ability ability = new Ability(abilityDbModel.Name, abilityDbModel.RequiredLevel, abilityDbModel.HealthChangeValue,
            abilityDbModel.ManaChangeValue, abilityDbModel.ManaAttackChangeValue, abilityDbModel.PhysAttackChangeValue, 
            abilityDbModel.PhysDefenseChangeValue);

        return ability;
    }
}