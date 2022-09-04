using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarCraft
{
    class Dragon : Range
    {
        public int FireBreathLine = 100;

        public Dragon(string name, int health, int cost, 
            int lvl, bool isDestroyed, int speed, int damage,
            int attackSpeed, int armor, int range, int mana) : 
            base(name, health, cost, lvl, isDestroyed, speed, 
                damage, attackSpeed, armor, range, mana)
        {
        }

        public void FireBreath()
        {
            if (FireBreathLine > 0)
            {
                Mana -= FireBreathLine;
            }
        }

        public string Attack()
        {
            return $"Dragon attacks with damage {Damage}.{Damage}";
        }
    }
}
