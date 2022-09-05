using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warcraft3
{
    internal class FootMan:Military
    {
        public FootMan(string name, int health, int cost, int lvl, int maxHP, int speed) : base(name, health, cost, lvl, maxHP, speed)
        {
        }

        public void Berserker(Military military) 
        {
            military.SetAttackSpeed(military.GetAttackSpeed() - 3);
        }
        public void Stun() 
        {
            Console.WriteLine("I'm stun");
        }
    }
}
