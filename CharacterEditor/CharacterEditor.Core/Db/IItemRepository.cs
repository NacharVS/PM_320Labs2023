using CharacterEditor.Core.Misc;

namespace CharacterEditor.Core.Db;

public interface IItemRepository
{
    public IEnumerable<Item> GetUniversalItems();
    public IEnumerable<Item> GetItemsByClass(string className);
    public void InitializeCollection();
}