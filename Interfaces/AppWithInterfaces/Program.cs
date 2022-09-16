using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryWithInterfaces;

namespace AppWithInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Shooter shooter = new Shooter();
            Mechanic mechanic = new Mechanic();
            Knife knife = new Knife(10, 5, 5);
            Machinegun machinegun = new Machinegun(20, 12, 30);
            Shotgun shotgun = new Shotgun(15, 10, 10);
            Shuriken shuriken = new Shuriken(8);
            Sword sword = new Sword(10, 5);

        }
    }
}