using System;

namespace Characters
{
	public class Rogue : Character
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
                    Damage += (value - strength) * 2;
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
                    Damage += (value - dexterity) * 4;
                    PhysDef += (value - dexterity) * 1.5;

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
                    HP += (value - constitution) * 6;

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
                    MP += (value - inteligence) * 1.5;
                    MagDamage += (value - inteligence) * 2;

                    inteligence = value;
                }

            }
        }
        public Rogue()
		{
            maxStrength = 55;
            maxDexterity = 250;
            maxConstitution = 80;
            maxInteligence = 70;
            Strength = 15;
            Dexterity = 30;
            Constitution = 20;
            Inteligence = 15;
        }
	}
}
