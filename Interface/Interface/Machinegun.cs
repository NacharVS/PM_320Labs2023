using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWithInterface
{
    class Machinegun : IFirearms, IAutoShot
    {
        public int _gunshotDamage = 20;

        public int GunshotDamage
        {
            get { return _gunshotDamage; }
            set { _gunshotDamage = value; }
        }

        public void SingleShot()
        {
            Console.WriteLine($"Single shot from a machine gun");
        }

        public void AutoShot()
        {
            Console.WriteLine($"Several shots from the machine gun");
        }
    }
}
