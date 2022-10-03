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
    
    public IEnumerable<Item> GetAllItems()
    {
        return Items.Find(x => true)
            .ToEnumerable()
            .Select(x => new Item
            {
                Name = x.Name ?? String.Empty, AttackChange = x.AttackChange,
                HealthChange = x.HealthChange,
                ManaChange = x.ManaChange,
                MagicalAttackChange = x.MagicalAttackChange,
                PhysicalResistanceChange = x.PhysicalResistanceChange,
                ClassName=x.ClassName, Type = x.Type, MinimumLevel = x.MinimumLevel
            });
    }

    public void InitializeCollection()
    {
        throw new NotImplementedException();
    }
}