using CharacterEditor.Core.Misc;

namespace CharacterEditor.Core.Db;

public interface IItemRepository
{
    public IEnumerable<Item> GetAllItems();
    public void InitializeCollection();
}