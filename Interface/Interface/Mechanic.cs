using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWithInterface
{
    class Mechanic
    {
        public void Upgrade(IUpgrade item)
        {
            item.Upgrade();
        }
    }
}
