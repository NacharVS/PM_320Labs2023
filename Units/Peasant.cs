using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units
{
    public class Peasant : Movable
    {
        public Peasant(int health) : base(health)
        {
        }
        public void Mining()
        {
            Console.WriteLine("Peasant is mining ore");
        }
        public void Chopping()
        {
            Console.WriteLine("Peasant is chopping woods");
        }

        public override void Move()
        {
            Console.WriteLine("Peasant is moving");
        }
    }
}
