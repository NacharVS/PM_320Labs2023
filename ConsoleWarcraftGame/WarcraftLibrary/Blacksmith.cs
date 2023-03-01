using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarcraftLibrary
{
    public class Blacksmith : Unit
    {
        public Blacksmith(string name, int health = 20, int cost = 10, int lvl = 1, bool isDestroyed = false, int damage = 0, int attackSpeed = 0) : base(name, health, cost, lvl, isDestroyed, damage, attackSpeed)
        { }

        public void UpgradeArmor(Military unit) 
        {
            if (unit.AttackSpeed + 5 >= 500)
            {
                unit.Armor += 5;
            }
            else
            {
                unit.Armor += 5;
                unit.AttackSpeed += 40;
            }
        }

        public void UpgradeWeapoon(Unit unit) 
        {
            unit.Damage += 5;
        }

        public void UpgradeBow(Unit unit) 
        {
            if (unit.AttackSpeed + 5 >= 500)
            {
                unit.Damage += 5;
            }
            else
            {
                unit.Damage += 5;
                unit.AttackSpeed += 100;
            }

        }

        public override string Attack(Unit unit, Blacksmith blacksmith)
        {
            return $"{Name} не может нанести удар.{0}";
        }
    }
}
