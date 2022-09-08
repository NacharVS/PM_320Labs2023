using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units.BaseUnits
{
    public abstract class Movable : Unit
    {
        private double _speed;

        public Movable(double health, string name) : base(name, health)
        {
        }

        public abstract void Move();
    }
}
