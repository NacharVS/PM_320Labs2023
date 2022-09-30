using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterEditorCore
{
    public static class AbilitiesList
    {
        public static readonly List<Ability> Abilities = new(){
            new Ability("Titan", 0, 0, 0, 20, 20),
            new Ability("Mammoth",0,0,0,50,0),
            new Ability("Cataclyscmic slam",20,10,0,0,0),
            new Ability("Weaken mind", 0,-5,-5,0,0),
            new Ability("Violent",10,10,0,0,5),
            new Ability("Magic Shield", 0,0,0,0,20),
            new Ability("Mana boost", 0,0,50,0,0),
            new Ability("Dominator", 10,10,10,10,10),
            new Ability("Super dominator",100,100,100,100,100),
            new Ability("Magic wind", 0,50,0,0,5)
        };
    }
}
