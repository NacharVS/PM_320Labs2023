using System;

namespace Characters
{
    public class Wizard:Character
    {
        public new int Strength
        {
            get { return strength; }
            set
            {
                if (value > maxStrength)
                {

                }
                else
                {
                    Damage += (value - strength) * 3;
                    HP += value - strength;

                    strength = value;
                }

            }
        }
        public new int Dexterity
        {
            get { return dexterity; }
            set
            {
                if (value > maxDexterity)
                {

                }
                else
                {
                    PhysDef += (value - dexterity) * 0.5;

                    dexterity = value;
                }

            }
        }
        public new int Constitution
        {
            get { return constitution; }
            set
            {
                if (value > maxConstitution)
                {

                }
                else
                {
                    HP += (value - constitution) * 3;
                    PhysDef += value - constitution;

                    constitution = value;
                }

            }
        }
        public new int Inteligence
        {
            get { return inteligence; }
            set
            {
                if (value > maxInteligence)
                {

                }
                else
                {
                    MP += (value - inteligence) * 2;
                    MagDamage += (value - inteligence) * 5;

                    inteligence = value;
                }

            }
        }
        public Wizard()
        {
            maxStrength = 45;
            maxDexterity = 70;
            maxConstitution = 60;
            maxInteligence = 250;
            Strength = 10;
            Dexterity = 20;
            Constitution = 15;
            Inteligence = 35;
        }
    }
}
