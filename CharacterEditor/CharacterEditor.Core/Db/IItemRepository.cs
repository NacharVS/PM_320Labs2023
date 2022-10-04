using CharacterEditor.Core.Misc;

namespace CharacterEditor.Core.Db;

public interface IItemRepository
{
    public IEnumerable<Item> GetItemsByClass(string className);
    public void InitializeCollection();
}