using InterfacesWar_Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesWar_Core.Units
{
    internal class Engineer
    {
        int hp = 100;
        public Engineer()
        {
        }

        public void Upgrade(IUpgrade weapon)
        {
            weapon.Upgrade();
        }
    }
}
