using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWithInterface
{
    class Sword : IMeleeWeapons
    {
        public int _meleeeDamage = 5;

        public int MeleeDamage
        {
            get { return _meleeeDamage; }
            set { _meleeeDamage = value; }
        }

        public void MeleeHit()
        {

        }
    }
}
