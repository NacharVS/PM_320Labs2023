using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCharacterEditor
{
    class Helmet : Armor
    {
        public string Material { get; set; }

        public Helmet(string material) : base(material)
        {
            Material = material;
        }

        public void CheckHelmet(Character character, string material) 
        {
            switch (material)
            {
                case "Copper":
                    character.Strength += 10;
                    character.Intelligence += 30;
                    character.HP += 30;
                    character.MP += 30;
                    character.PDef = 10;
                    character.Attack = 10;
                    break;
                case "Silver":
                    character.Strength += 20;
                    character.Intelligence += 40;
                    character.HP += 40;
                    character.MP += 40;
                    character.PDef = 20;
                    character.Attack = 20;
                    break;
                case "Gold":
                    character.Strength += 30;
                    character.Intelligence += 50;
                    character.HP += 50;
                    character.MP += 50;
                    character.PDef = 30;
                    character.Attack = 30;
                    break;
            }
        }
    }
}
