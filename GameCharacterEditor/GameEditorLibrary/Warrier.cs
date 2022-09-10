using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEditorLibrary
{
    public class Warrier : Unit
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

        public Warrier()
        {
            strength = 30;
            dexterity = 15;
            constitution = 20;
            intelligence = 10;
            maxIintelligence = 50;
            minIntelligence = 10;
            minStrength = 30;
            maxStrength = 250;
            minDexterity = 15;
            maxDexterity = 70;
            minConstitution = 20;
            maxConstitution = 100;
        }

    }
}
