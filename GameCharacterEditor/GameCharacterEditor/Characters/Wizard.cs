using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCharacterEditor.Characters
{
    class Wizard : Character
    {
        public Wizard(string name, int minStrength, int maxStrength, 
            int minDexterity, int maxDexterity, int minConstitution, 
            int maxConstitution, int minIntelligence, int maxIntelligence, 
            int mP, int hP, int pDef, int attack) : base(name, minStrength, 
                maxStrength, minDexterity, maxDexterity, minConstitution, 
                maxConstitution, minIntelligence, maxIntelligence, mP, hP, 
                pDef, attack)
        {
        }
    }
}
