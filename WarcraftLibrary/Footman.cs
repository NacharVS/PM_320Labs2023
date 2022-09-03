using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarcraftLibrary
{
    public class Footman : Military
    {
        public Footman(string name, int health = 40, int cost = 10, int lvl = 1, bool isDestroyed = false, int speed = 12, int damage = 10, int attackSpeed = 5, int armor = 5) : base(name, health, cost, lvl, isDestroyed, speed, damage, attackSpeed, armor) { }

        public static void Berserker() 
        { }

        public static void Stun() 
        { }

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
