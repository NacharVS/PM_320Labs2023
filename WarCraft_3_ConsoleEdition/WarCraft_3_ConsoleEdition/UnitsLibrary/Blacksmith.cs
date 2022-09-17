using System.Collections.Generic;

namespace WarCraft_3_ConsoleEdition
{
    public class Blacksmith : Unit
    {
        private int _boost = 3;

        public Blacksmith(int health, int cost, string name, int level) 
            : base( health, cost, name, level)
        {
        }
        public void UpgradeArmor(List<Military> units)
        {
            for(int i = 0; i < units.Count; i++)
            {
                units[i].Armor += _boost;
            }
        }
        public void UpgradeWeapon(List<Military> units)
        {
            for (int i = 0; i < units.Count; i++)
            {
                units[i].Damage += _boost;
            }
        }
        public void UpgradeBow(List<Archer> units)
        {
            for (int i = 0; i < units.Count; i++)
            {
                units[i].Distance += _boost;
                units[i].Damage += _boost;
            }
        }
    }
}
