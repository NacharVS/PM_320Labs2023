using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarCraft
{
    class Footman : Military
    {
        public Footman(string name, int health, int cost, 
            int speed, int damage, int attackSpeed, int armor) : 
            base(name, health, cost, speed, damage, attackSpeed, armor)
        {
            /*HealthChangedEvent += Berserker;*/
        }

        public void Berserker() { }

        public void Stun() { }

        public override string Attack(int number, Military player1, Military player2)
        {
            return $"Footman attacks with damage {Damage}";
        }
    }
}
