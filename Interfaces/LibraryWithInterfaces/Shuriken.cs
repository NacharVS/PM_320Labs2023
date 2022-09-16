using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWithInterfaces
{
    public class Shuriken : IThrowable
    {
        public int ThrowDamage { get; set; }

        public Shuriken(int throwDamage)
        {
            ThrowDamage = throwDamage;
        }

        public void Throw()
        {
            Console.WriteLine("");
        }
    }
}
