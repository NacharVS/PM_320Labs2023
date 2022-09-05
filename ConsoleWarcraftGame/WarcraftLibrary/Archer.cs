using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarcraftLibrary
{
    public class Archer : Military
    {
        Random rnd = new Random();
        public int Arrows;

        public Archer(string name, int health = 70, int cost = 25, int lvl = 1, bool isDestroyed = false, int speed = 12, int damage = 8, int attackSpeed = 1, int armor = 5, int arrows = 20) : base(name, health, cost, lvl, isDestroyed, speed, damage, attackSpeed, armor) 
        {
            Arrows = arrows;
        }

        public override string Attack()
        {
            var val = rnd.Next(1, 6);
            if (Arrows == 0)
            {
                return $"{Name} не смог нанести удар, закончились стрелы.{0}";
            }
            if (val == 3)
            {
                return $"{Name} не смог нанести удар.{0}";
            }
            Arrows--;
            return $"{Name} нанес удар с силой {Damage}.{Damage}";
        }
    }
}
