using CharacterEditor.Core;
using CharacterEditor.Core.Db;
using MongoDB.Driver;

namespace CharacterEditor.MongoDB;

public class AbilityRepository : IAbilityRepository
{
    private IMongoCollection<AbilityDb> Abilities { get; }

    public AbilityRepository(MongoConnection connection)
    {
        Abilities =
            connection.Database?.GetCollection<AbilityDb>("Abilities")!;
    }

    public IEnumerable<Ability> GetAllAbilities()
    {
        return Abilities.Find(x => true)
            .ToEnumerable()
            .Select(x => new Ability
            {
                Name = x.Name, AttackChange = x.AttackChange,
                HealthChange = x.HealthChange,
                ManaChange = x.ManaChange,
                MagicalAttackChange = x.MagicalAttackChange,
                PhysicalResistanceChange = x.PhysicalResistanceChange
            });
    }
}