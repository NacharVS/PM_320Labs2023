using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCharacterEditor
{
    class Shield : Armor
    {
        public Shield(string material) : base(material) { }

        public void CheckShild(Character character, string material)
        {
            switch (material)
            {
                case "Copper":
                    character.Strength += 30;
                    character.Dexterity += 40;
                    character.HP += 50;
                    character.MP += 20;
                    character.PDef = 20;
                    character.Attack = 30;
                    break;
                case "Silver":
                    character.Strength += 40;
                    character.Dexterity += 50;
                    character.HP += 60;
                    character.MP += 30;
                    character.PDef = 30;
                    character.Attack = 40;
                    break;
                case "Gold":
                    character.Strength += 50;
                    character.Dexterity += 60;
                    character.HP += 70;
                    character.MP += 40;
                    character.PDef = 40;
                    character.Attack = 50;
                    break;
            }
        }
    }
}
