using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units
{
    public abstract class Movable : Unit
    {
        private double _speed;
        public Movable(double health) : base(health)
        {
        }
        public abstract void Move();
    }
}
