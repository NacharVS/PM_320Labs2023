using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarcraftLibrary
{
    public class Blacksmith : Unit
    {
        public Blacksmith(string name, int health = 20, int cost = 10, int lvl = 1, bool isDestroyed = false, int damage = 0) : base(name, health, cost, lvl, isDestroyed, damage)
        { }

        public void UpgradeArmor(List<Military> units) 
        {
            foreach (var unit in units)
            {
                unit.Armor += 5;
            }
        }

        public void UpgradeWeapoon(List<Military> units) 
        {
            foreach (var unit in units)
            {
                unit.Damage += 5;
            }
        }

        public void UpgradeBow(List<Military> units) 
        {
            foreach (var unit in units)
            {
                unit.Damage += 5;
            }
        }

        public override string Attack()
        {
            return $"{Name} не может нанести удар.{0}";
        }
    }
}
