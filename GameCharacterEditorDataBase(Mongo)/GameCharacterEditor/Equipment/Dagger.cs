using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCharacterEditor
{
    class Dagger : Equipment
    {
        /*public Dagger()
        {
            EquipmentName = "Dagger";
            EquipmentCount = 10;
        }*/
        public Dagger(string equipmentName, int equipmentCount) : base(equipmentName, equipmentCount)
        {
        }
    }
}
