using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units_Practic.Items
{
    public abstract class ChestArmor : Item, IEquipment
    {
        public bool equip { get; set; }

        public ChestArmor()
        {
            type = TypeItem.ChestArmor;
        }
    }
}
