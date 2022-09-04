using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarCraft
{
    class Moveable : Unit
    {
        public int Speed { get; set; }

        public Moveable(string name, int health, 
            int cost, int lvl, bool isDestroyed, 
            int speed) : base(name, health, cost, 
                lvl, isDestroyed)
        {
            this.Speed = speed;
        }

        public void Move() { }
    }
}
