using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesWar_Core.Interfaces
{
    internal interface IAutomaticShoot : IWeapon, IUpgrade
    {
        public void AutoShoot();
    }
}
