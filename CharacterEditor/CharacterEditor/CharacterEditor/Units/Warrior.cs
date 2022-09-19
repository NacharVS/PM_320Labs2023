using System;

namespace Characters
{
    public class Warrior : Character
    {
        public new int Strength 
        { 
            get { return strength; }
            set 
            {  
                if (value > MaxStrength)
                {

                }
                else
                {
                    Damage += (value - strength) * 5;
                    HP += (value - strength) * 2;

                    strength = value;
                }

            }
        }
        public new int Dexterity 
        {
            get { return dexterity; }
            set
            {
                if (value > MaxDexterity)
                {

                }
                else
                {
                    Damage += value - dexterity;
                    PhysDef += value - dexterity;

                    dexterity = value;
                }

            }
        }
        public new int Constitution 
        {
            get { return constitution; }
            set
            {
                if (value > MaxConstitution)
                {

                }
                else
                {
                    HP += (value - constitution) * 10; 
                    PhysDef += (value - constitution) * 2;

                    constitution = value;
                }

            }
        }
        public new int Inteligence 
        {
            get { return inteligence; }
            set
            {
                if (value > MaxInteligence)
                {

                }
                else
                {
                    MP += value - inteligence;
                    MagDamage += value - inteligence;

                    inteligence = value;
                }

            }
        }

        public Warrior()
        {
            MaxStrength = 250;
            MaxDexterity = 70;
            MaxConstitution = 100;
            MaxInteligence = 50;
            Strength = 30;
            Dexterity = 15;
            Constitution = 20;
            Inteligence = 10;
        }

    }
}
