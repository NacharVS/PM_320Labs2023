using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCharacterEditor
{
    class ChainMail : Armor
    {
        public ChainMail(string material) : base(material) { }

        public void CheckChainMail(Character character, string material) 
        {
            switch (material)
            {
                case "Copper":
                    character.Strength += 1;
                    character.Dexterity += 1;
                    character.HP += 1;
                    character.MP += 1;
                    character.PDef = 1;
                    character.Attack = 1;
                    break;
                case "Silver":
                    character.Strength += 2;
                    character.Dexterity += 2;
                    character.HP += 2;
                    character.MP += 2;
                    character.PDef = 2;
                    character.Attack = 2;
                    break;
                case "Gold":
                    character.Strength += 3;
                    character.Dexterity += 3;
                    character.HP += 3;
                    character.MP += 3;
                    character.PDef = 3;
                    character.Attack = 3;
                    break;
            }
        }
    }
}
