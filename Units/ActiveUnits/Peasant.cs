using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Units.BaseUnits;

namespace Units.ActiveUnits
{
    public class Peasant : Movable
    {
        public Peasant(double health, string name) : base(health, name)
        {
        }
        public void Mining()
        {
            Console.WriteLine($"Peasant is mining ore");
        }
        public void Chopping()
        {
            Console.WriteLine($"Peasant is chopping woods");
        }

        public override void Move()
        {
            Console.WriteLine($"Peasant is moving");
        }
    }
}
