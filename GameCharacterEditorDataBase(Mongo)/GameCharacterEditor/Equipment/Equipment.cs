using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCharacterEditor
{
    class Equipment
    {
        public string EquipmentName { get; set; }
        public int EquipmentCount { get; set; }

        public Equipment (string equipmentName, int equipmentCount)
        {
            EquipmentName = equipmentName;
            EquipmentCount = equipmentCount;
        }
    }
}
