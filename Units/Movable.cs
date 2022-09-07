using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units
{
    public abstract class Movable : Unit
    {
        private double _speed { get; set; }

        public abstract void Move();
    }
}
