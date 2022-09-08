using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarcraftLibrary
{
    public class Dragon : Range
    {
        Random rnd = new Random();

        public Dragon(string name, int health = 500, int cost = 350, int lvl = 1, bool isDestroyed = false, int speed = 30, int damage = 50, int attackSpeed = 3, int armor = 100, int range = 40, int mana = 80) : base(name, health, cost, lvl, isDestroyed, speed, damage, attackSpeed, armor, range, mana) { }

        public string FireBreath() 
        {
            Mana -= 10;
            return $"{Name} нанес удар с помощью firebreath {Damage + 10}.{Damage + 10}";
        }

        public override string Attack(Blacksmith blacksmith)
        {
            var val = rnd.Next(1, 6);

            if (val == 3)
            {
                return $"{Name} не смог нанести удар.{0}";
            }
            if (val == 4 && Mana > 10)
            {
                return FireBreath();
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
