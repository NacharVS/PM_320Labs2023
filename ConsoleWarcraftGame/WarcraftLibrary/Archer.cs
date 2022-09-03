using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarcraftLibrary
{
    public class Archer : Military
    {
        public Archer(string name, int health = 70, int cost = 25, int lvl = 1, bool isDestroyed = false, int speed = 12, int damage = 8, int attackSpeed = 1, int armor = 5) : base(name, health, cost, lvl, isDestroyed, speed, damage, attackSpeed, armor) { }

        public override string Attack(int num)
        {
            if (num == 0)
            {
                return $"{Name} не смог нанести удар.{0}";
            }
            return $"{Name} нанес удар с силой {Damage}.{Damage}";
        }
    }
}
