using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWithInterface
{
    public class Mechanic
    {
        public void Upgrade(IUpgrade weapon)
        {
            weapon.Upgrade();
        }

        public void Repair(IRepairible weapon)
        {
            weapon.Repair();
        }
    }
}
