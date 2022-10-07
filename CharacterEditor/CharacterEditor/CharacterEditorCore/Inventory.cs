namespace CharacterEditorCore
{
    public class Inventory
    {
        public List<Item> Items { get; private set; }
        private const int _inventoryCapacity = 10;

        public Inventory ()
        {
            Items = new List<Item>();
            Items.Capacity = _inventoryCapacity;
        }

        public Inventory(List<Item> items)
        {
            if (items.Count > _inventoryCapacity)
            {
                var arr = new Item[_inventoryCapacity];
                items.CopyTo(0, arr, 0, _inventoryCapacity);
                Items = arr.ToList();
            }
            else
            {
                Items = items;
                Items.Capacity = _inventoryCapacity;
            }
        }

        public void AddItem(Item item)
        {
            if (item == null)
            {
                return;
            }

            Items.Add(item);
        }

        public bool DeleteItemByName(string name)
        {
            var item = Items.Find(x => x.Name == name);

            if (item == null)
            {
                return false;
            }

            return Items.Remove(item);
        }     
        
        public void Clear()
        {
            Items.Clear();
            Items.Capacity = _inventoryCapacity;
        }
    }
}