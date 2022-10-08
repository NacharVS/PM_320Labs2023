using CharacterEditor.Core.Db;
using CharacterEditor.Core.Misc;
using MongoDB.Driver;

namespace CharacterEditor.MongoDB;

public class ItemRepository : RepositoryBase, IItemRepository
{
    private IMongoCollection<ItemDb> Items { get; }

    public ItemRepository(MongoConnection connection)
    {
        Items = connection.Database?.GetCollection<ItemDb>("Items")!;
    }

    public IEnumerable<Item> GetUniversalItems()
    {
        return Items.Find(x => x.Type == ItemType.Universal)
            .ToEnumerable()
            .Select(x => ConvertItem(x));
    }

    public IEnumerable<Item> GetItemsByClass(string className)
    {
        return Items.Find(x => x.ClassName == className)
            .ToEnumerable()
            .Select(x => ConvertItem(x));
    }

    public void InitializeCollection()
    {
        foreach (var item in Defaults.DefaultItems)
        {
            var storedItem = Items.Find(x => x.Name == item.Name)
                .FirstOrDefault();
            if (storedItem is not null)
                continue;

            Items.InsertOne(ConvertItem(item));
        }
    }
}