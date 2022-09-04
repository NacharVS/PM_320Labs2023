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
            int lvl, bool isDestroyed, int speed) : base(name, 
                health, cost, lvl, isDestroyed, speed)
        {
        }

        public void Mining() { }

        public void Choping() { }
    }
}
