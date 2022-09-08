using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarCraft
{
    class Mage : Range
    {
        public static int FireBallLine = 10;
        public static int BlizzardLine = 20;
        public static int HealLine = 30;

        public Mage(string name, int health, 
            int cost, int lvl, bool isDestroyed,
            int speed, int damage, int attackSpeed, 
            int armor, int range, int mana) : base(name, 
                health, cost, lvl, isDestroyed, speed, damage, 
                attackSpeed, armor, range, mana)
        {
        }

        public void FireBall()
        {
            if (FireBallLine > 0)
            {
                Mana -= FireBallLine;
            }
        }
        
        public void Blizzard()
        {
            if (BlizzardLine > 0)
            {
                Mana -= BlizzardLine;
            }
        }
        
        public void Heal()
        {
            if (HealLine > 0)
            {
                Mana -= HealLine;
            }
        }

        public override string Attack (int number)
        {
            var random = new Random();
            int attack = random.Next(1, 5);

            switch (attack)
            {
                case 1:
                    FireBall();
                    return $"The magician used a Fireball and " +
                        $"dealt {Damage} damage";
                    break;
                case 2:
                    Blizzard();
                    return $"The magician used a Blizzard and " +
                        $"dealt {Damage} damage";
                    break;
                case 3:
                    Heal();
                    return $"The magician used a Heal and " +
                        $"dealt {Damage} damage";
                    break;
                case 4:
                    return $"Mage attacks with damage {Damage}";
                    break;
            }
            return "";
        }
    }
}
