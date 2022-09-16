using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWithInterface
{
    class Pistol : IFirearms
    {
        public int _gunshotdamage = 10;

        public int GunshotDamage
        {
            get { return _gunshotdamage; }
            set { _gunshotdamage = value; }
        }

        public void SingleShot()
        {
            throw new NotImplementedException();    
        }
    }
}
