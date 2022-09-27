namespace CharacterEditorCore
{
    public class Inventory
    {
        List<IItem> _inventory;

        public Inventory ()
        {
            _inventory = new List<IItem>();
        }

        public void AddItem (IItem item)
        {
            if (item == null)
            {
                return;
            }

            _inventory.Add(item);
        }

        public bool DeleteItemByName(string name)
        {
            var item = _inventory.Find(x => x.Name == name);

            if (item == null)
            {
                return false;
            }

            return _inventory.Remove(item);
        }      
    }
}