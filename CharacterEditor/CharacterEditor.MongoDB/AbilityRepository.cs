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
                Name = x.Name ?? String.Empty, AttackChange = x.AttackChange,
                HealthChange = x.HealthChange,
                ManaChange = x.ManaChange,
                MagicalAttackChange = x.MagicalAttackChange,
                PhysicalResistanceChange = x.PhysicalResistanceChange
            });
    }

    public void InitializeCollection()
    {
        foreach (var ability in Defaults.DefaultAbilities)
        {
            var storedAbility = Abilities.Find(x => x.Name == ability.Name)
                .FirstOrDefault();
            if (storedAbility is not null)
                continue;

            Abilities.InsertOne(new AbilityDb
            {
                Name = ability.Name,
                AttackChange = ability.AttackChange,
                HealthChange = ability.HealthChange,
                ManaChange = ability.ManaChange,
                MagicalAttackChange = ability.MagicalAttackChange,
                PhysicalResistanceChange = ability.PhysicalResistanceChange
            });
        }
    }
}