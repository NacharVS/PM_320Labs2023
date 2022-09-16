using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWithInterface
{
    class Automat : IFirearms, IAutoShot
    {
        public int _gunshotDamage = 20;

        public int GunshotDamage
        {
            get { return _gunshotDamage; }
            set { _gunshotDamage = value; }
        }

        public void SingleShot()
        {

        }

        public void AutoShot()
        {

        }
    }
}
