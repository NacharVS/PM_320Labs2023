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

        public Moveable(string name, int health, int cost,
            int speed) : base(name, health, cost)
        {
            this.Speed = speed;
        }

        public void Move() { }
    }
}
