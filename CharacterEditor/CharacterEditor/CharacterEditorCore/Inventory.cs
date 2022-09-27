namespace CharacterEditorCore
{
    public class Inventory
    {
        public List<IItem> Items { get; private set; }

        public Inventory ()
        {
            Items = new List<IItem>();
        }

        public Inventory(List<IItem> items)
        {
            Items = items;
        }

        public void AddItem(IItem item)
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
    }
}