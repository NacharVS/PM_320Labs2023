using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesWar_Core.Interfaces
{
    internal interface ISingleShoot : IWeapon, IUpgrade
    {
        public void SingleShoot();
    }
}
