using Editor.Core.Inventory;

namespace Editor.Core.Helpers;

public class InventoryChangeArgs : EventArgs
{
    public InventoryItem Item { get; set; }

    public InventoryChangeArgs(InventoryItem item)
    {
        Item = item;
    }
}