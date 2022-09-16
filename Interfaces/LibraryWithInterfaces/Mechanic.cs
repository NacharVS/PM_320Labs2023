using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWithInterfaces
{
    public class Mechanic
    {
        public Mechanic() { }

        public void Repair(IRepairible weapon)
        {
            weapon.Repair();
        }

        public void Upgrade(IUpgradeble weapon)
        {
            weapon.Upgrade();
        }
    }
}
