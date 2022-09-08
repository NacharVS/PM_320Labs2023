using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarcraftLibrary
{
    public class Footman : Military
    {
        Random rnd = new Random();
        private int _maxHealth;

        public Footman(string name, int health = 40, int cost = 10, int lvl = 1, bool isDestroyed = false, int speed = 12, int damage = 10, int attackSpeed = 5, int armor = 5) : base(name, health, cost, lvl, isDestroyed, speed, damage, attackSpeed, armor)
        { 
            _maxHealth = health;
        }

        public string Berserker() 
        {
            return $"{Name} нанес удар с силой {Damage * 1.5}.{Damage * 1.5}";
        }

        public static void Stun(Moveable unit) 
        {
            unit.Speed -= 10;
        }

        public override string Attack(Blacksmith blacksmith)
        {
            var val = rnd.Next(1, 6);

            if (val == 3)
            {
                return $"{Name} не смог нанести удар.{0}";
            }
            if (val == 4 && Health < _maxHealth/2)
            {
                return Berserker();
            }
            if (val == 5)
            {
                blacksmith.UpgradeArmor(this);
                return $"{Name} улучшил броню.{0}";
            }
            return $"{Name} нанес удар с силой {Damage}.{Damage}";
        }
    }
}
