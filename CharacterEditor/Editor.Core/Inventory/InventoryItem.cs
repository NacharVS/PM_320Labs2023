namespace Editor.Core.Inventory
{
    public class InventoryItem
    {
        public string? Name { get; set; }

        public InventoryItem(string? name)
        {
            Name = name;
        }
    }
}
