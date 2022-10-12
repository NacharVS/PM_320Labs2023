using Editor.Core.Characters.interfaces;

namespace Editor.Core.Inventory
{
    public class InventoryItem : IHaveName
    {
        public string? Name { get; set; }

        public InventoryItem(string? name)
        {
            Name = name;
        }

        public virtual string GetDescription()
        {
            return $"Name: {Name}";
        }
    }
}
