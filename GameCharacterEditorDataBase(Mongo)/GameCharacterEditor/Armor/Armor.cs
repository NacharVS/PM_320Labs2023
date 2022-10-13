using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCharacterEditor
{
    class Armor
    {
        public string ArmorMaterial { get; set; }

        public Armor (string material)
        {
            ArmorMaterial = material;
        }

        public void Check (Character character, string material)
        {

        }
    }
}
