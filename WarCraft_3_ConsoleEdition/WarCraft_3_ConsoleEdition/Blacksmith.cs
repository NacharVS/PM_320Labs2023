namespace WarCraft_3_ConsoleEdition
{
    class Blacksmith : Unit
    {
        private int boost = 3;
        public Blacksmith(int health, int cost, string name, int level) : base( health, cost, name, level)
        {
        }
        public void UpgradeArmor(List<Military> units)
        {
            for(int i = 0; i < units.Count; i++)
            {
                units[i].armor += boost;
            }
        }

        public void UpgradeWeapon(List<Military> units)
        {
            for (int i = 0; i < units.Count; i++)
            {
                units[i].damage += boost;
            }
        }

        public void UpgradeBow(List<Archer> units)
        {
            for (int i = 0; i < units.Count; i++)
            {
                units[i].range += boost;
                units[i].damage += boost;
            }
        }
    }
}
