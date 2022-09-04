using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarCraft
{
    class Footman : Military
    {
        public Footman(string name, int health, 
            int cost, int lvl, bool isDestroyed, 
            int speed, int damage, int attackSpeed, 
            int armor) : base(name, health, cost, lvl,
                isDestroyed, speed, damage, attackSpeed, 
                armor)
        {
            speed = 7;
            armor = 2;
            damage = 9;
            cost = 135;
        }

        public void Berserker() { }

        public void Stun() { }

        public string Attack()
        {
            return $"Footman attacks with damage {Damage}.{Damage}";
        }
    }
}
