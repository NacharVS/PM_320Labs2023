using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCharacterEditor
{
    class Bow : Equipment
    {
        public Bow(string equipmentName, int equipmentCount) : 
            base(equipmentName, equipmentCount)
        {
            TypeEquipment = "Bow";
        }
    }
}
