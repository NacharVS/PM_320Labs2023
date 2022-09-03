using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarcraftLibrary
{
    public class Mage : Range
    {
        Random rnd = new Random();

        public Mage(string name, int health = 200, int cost = 80, int lvl = 1, bool isDestroyed = false, int speed = 20, int damage = 50, int attackSpeed = 2, int armor = 5, int range = 3, int mana = 100) : base(name, health, cost, lvl, isDestroyed, speed, damage, attackSpeed, armor, range, mana) { }

        public string FireBall() 
        {
            Mana -= 10;
            return $"{Name} нанес удар с помощью fireball {Damage + 10}.{Damage + 10}";
        }
        
        public void Blizzard() { }
        
        public void Heal()
        {
            Mana -= 6;
            Health += 5;
        }

        public override string Attack(int num)
        {
            if (Health > 0 && rnd.Next(1, 6) == 2 && Health < 195 && Mana > 6)
            {
                Heal();
                if (num == 0)
                {
                    return $"{Name} не смог нанести удар, но воспользовался хилом +5.{0}";
                }
                if (num == Damage + 10 && Mana > 10)
                {
                    return $"{Name} нанес удар с помощью fireball {Damage + 10} и воспользовался хилом +5.{Damage + 10}";
                }
                return $"{Name} нанес удар с силой {Damage} и воспользовался хилом +5.{Damage}";
            }
            if (num == Damage + 10 && Mana > 10)
            {
                return FireBall();
            }
            if (num == 0)
            {
                return $"{Name} не смог нанести удар.{0}";
            }
            return $"{Name} нанес удар с силой {Damage}.{Damage}";
        }
    }
}
