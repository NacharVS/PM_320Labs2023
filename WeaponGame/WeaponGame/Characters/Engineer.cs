namespace WeaponGame.Characters
{
    public class Engineer
    {
        public string Name { get; }

        public Engineer(string name)
        {
            Name = name;
        }

        public void Repair(IRepairible item)
        {
            item.Repair();
        }

        public void Upgrade(IUpgradable item)
        {
            item.Upgrade();
        }
    }
}