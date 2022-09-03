using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarcraftLibrary
{
    public class GuardTower : Unit
    {
        public int Range;
        public int AttackSpeed;

        public GuardTower(string name, int health = 300, int cost = 100, int lvl = 1, bool isDestroyed = false, int range = 80, int damage = 10, int attackSpeed = 1) : base(name, health, cost, lvl, isDestroyed, damage)
        {
            this.Range = range;
            this.AttackSpeed = attackSpeed;
        }

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
