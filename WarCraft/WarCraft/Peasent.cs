using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarCraft
{
    class Peasent : Moveable
    {
        public Peasent(string name, int health, int cost, 
            int speed) : base(name, health, cost,speed)
        {
        }

        public void Mining() { }

        public void Choping() { }
    }
}
