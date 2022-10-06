using CharacterEditor.Core.Db;
using CharacterEditor.Core.Misc;
using MongoDB.Driver;

namespace CharacterEditor.MongoDB;

public class ItemRepository : IItemRepository
{
    private IMongoCollection<ItemDb> Items { get; }

    public ItemRepository(MongoConnection connection)
    {
        Items = connection.Database?.GetCollection<ItemDb>("Items")!;
    }

    public IEnumerable<Item> GetItemsByClass(string className)
    {
        return Items.Find(x => x.ClassName == className)
            .ToEnumerable()
            .Select(x => new Item
            {
                Name = x.Name ?? String.Empty, AttackChange = x.AttackChange,
                HealthChange = x.HealthChange,
                ManaChange = x.ManaChange,
                MagicalAttackChange = x.MagicalAttackChange,
                PhysicalResistanceChange = x.PhysicalResistanceChange,
                ClassName = x.ClassName, Type = x.Type,
                MinimumLevel = x.MinimumLevel,
                ConstitutionChange = x.ConstitutionChange,
                DexterityChange = x.DexterityChange,
                IntelligenceChange = x.IntelligenceChange,
                StrengthChange = x.StrengthChange
            });
    }

    public void InitializeCollection()
    {
        foreach (var item in Defaults.DefaultItems)
        {
            var storedAbility = Items.Find(x => x.Name == item.Name)
                .FirstOrDefault();
            if (storedAbility is not null)
                continue;

            Items.InsertOne(new ItemDb
            {
                Name = item.Name, Type = item.Type,
                AttackChange = item.AttackChange,
                HealthChange = item.HealthChange,
                ManaChange = item.ManaChange,
                MagicalAttackChange = item.MagicalAttackChange,
                PhysicalResistanceChange = item.PhysicalResistanceChange,
                ClassName = item.ClassName, MinimumLevel = item.MinimumLevel,
                ConstitutionChange = item.ConstitutionChange,
                DexterityChange = item.DexterityChange,
                IntelligenceChange = item.IntelligenceChange,
                StrengthChange = item.StrengthChange
            });
        }
    }
}