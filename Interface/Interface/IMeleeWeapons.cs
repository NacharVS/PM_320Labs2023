using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWithInterface
{
    interface IMeleeWeapons
    {
        int MeleeDamage { get; set; }

        void MeleeHit();
    }
}
