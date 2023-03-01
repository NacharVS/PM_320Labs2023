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

        public Footman(string name, int health = 40, int cost = 10, int lvl = 1, bool isDestroyed = false, int speed = 12, int damage = 10, int attackSpeed = 140, int armor = 5) : base(name, health, cost, lvl, isDestroyed, speed, damage, attackSpeed, armor)
        {
            _maxHealth = health;
        }

        public string Berserker()
        {
            return $"{Name} нанес удар с силой {Damage * 1.5}.{Damage * 1.5}";
        }

        public string Stun(Moveable unit)
        {
            unit.Speed -= 20;
            return $"{Name} застанил противника.{0}";
        }

        public override string Attack(Unit unit, Blacksmith blacksmith)
        {
            var val = rnd.Next(1, 10);

            if (val == 3 || val == 2 || val == 1)
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
            if (val == 6 && unit.GetType() == typeof(Moveable))
            {
                return Stun((Moveable)unit);
            }
            return $"{Name} нанес удар с силой {Damage}.{Damage}";
        }
    }
}
