using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarCraft
{
    class Dragon : Range
    {
        public static int FireBreathLine = 100;

        public Dragon(string name, int health, int cost, 
            int speed, int damage, int attackSpeed, int armor,
            int range, int mana) : base(name, health, cost, speed, 
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

        public override string Attack(int number, Military player1, Military player2)
        {
            return $"Dragon attacks with damage {Damage}";
        }
    }
}
