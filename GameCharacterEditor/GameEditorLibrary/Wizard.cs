using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEditorLibrary
{
    public class Wizard : Unit
    {
        public int strength;
        public int dexterity;
        public int constitution;
        public int intelligence;

        public int attackDamage;
        public int manaAttack;
        public double phDefention;
        public double HP;
        public double MP;

        public Wizard()
        {
            strength = minStrength;
            dexterity = minDexterity;
            constitution = minConstitution;
            intelligence = minIntelligence;
            maxIintelligence = 250;
            minIntelligence = 35;
            minStrength = 10;
            maxStrength = 45;
            minDexterity = 20;
            maxDexterity = 70;
            minConstitution = 15;
            maxConstitution = 60;
        }
    }
}
