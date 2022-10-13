using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCharacterEditor
{
    class ChainMail
    {
        public string Material { get; set; }

        public ChainMail(string material)
        {
            Material = material;
        }

        public void CheckChainMail(Character character, string material) 
        {
            switch (material)
            {
                case "Copper":
                    character.Strength += 20;
                    character.Dexterity += 20;
                    character.HP += 50;
                    character.MP += 20;
                    character.PDef = 10;
                    character.Attack = 15;
                    break;
                case "Silver":
                    character.Strength += 30;
                    character.Dexterity += 30;
                    character.HP += 60;
                    character.MP += 30;
                    character.PDef = 20;
                    character.Attack = 25;
                    break;
                case "Gold":
                    character.Strength += 40;
                    character.Dexterity += 40;
                    character.HP += 70;
                    character.MP += 40;
                    character.PDef = 30;
                    character.Attack = 35;
                    break;
            }
        }
    }
}
