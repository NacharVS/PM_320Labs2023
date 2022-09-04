using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarCraft
{
    class Mage : Range
    {
        public int FireBallLine = 10;
        public int BlizzardLine = 20;
        public int HealLine = 30;

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

        public string Attack ()
        {
            return $"Mage attacks with damage {Damage}.{Damage}";
        }
    }
}
