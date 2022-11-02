using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCharacterEditor
{
    class Armor
    {
        public string ArmorName { get; set; }
        public string ArmorMaterial { get; set; }

        public Armor(string armorName, string material)
        {
            ArmorName = armorName;
            ArmorMaterial = material;
        }

        public void Check (Character character, string material, string armorName)
        {
            int count = 0;

            switch (material)
            {
                case "Copper":
                    count = 1;
                    AddCharacteristics(character, armorName, count);
                    break;
                case "Silver":
                    count = 2;
                    AddCharacteristics(character, armorName, count);
                    break;
                case "Gold":
                    count = 3;
                    AddCharacteristics (character, armorName, count);
                    break;
            }
        }

        public void AddCharacteristics(Character character, string armorName, int count)
        {
            character.Strength += count;
            character.HP += count;
            character.MP += count;
            character.PDef += count;
            character.Attack += count;

            switch (armorName)
            {
                case "Chain mail":
                    character.Constitution += count;
                    break;
                case "Helmet":
                    character.Intelligence += count;
                    break;
                case "Shield":
                    character.Dexterity += count;
                    break;
            }
        }
    }
}
