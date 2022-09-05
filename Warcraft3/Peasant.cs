using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warcraft3
{
    internal class Peasant: Moveble
    {
        public Peasant(string name, int health, int cost, int lvl, int maxHP, int speed) : base(name, health, cost, lvl, maxHP, speed)
        {
        }

        public void Mining() 
        {
            Console.WriteLine("I'm mining");
        }
        public void Choping() 
        {
            Console.WriteLine("I'm choping");
        
        }

    }
}
