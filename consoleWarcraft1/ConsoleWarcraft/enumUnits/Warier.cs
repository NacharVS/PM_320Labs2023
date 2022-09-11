using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWarcraft.enumUnits
{
    public class Warier
    {
        int strensthMin = 30;
        int strensthMax = 250;
        int desterityMin = 15;
        int desterityMax = 70;
        int constitutionMin = 20;
        int constitutionMax = 100;
        int intellisenseMin = 10;
        int intellisenseMax = 50;

        int currentStrensth = 0;
        int currentDesterity = 0;
        int currentConstitution = 0;
        int currentIntellisense = 0;

        public int health = 0;
        public int damage = 0;
        int magicPoints = 0;
        int pDet = 0;
        int mah = 0;

        public Warier()
        {
            currentStrensth = strensthMin;
            currentDesterity = desterityMin;
            currentConstitution = constitutionMin;
            currentIntellisense = intellisenseMin; ;
        }

        public int HP
        {
            get { return health; }
            set
            {
                health = value;
            }
        }

        public int MP
        {
            get { return magicPoints; }
            set
            {
                magicPoints = value;
            }
        }

        public int Attack
        {
            get { return damage; }
            set
            {
                damage = value;
            }
        }

        public int PDet
        {
            get { return pDet; }
            set
            {
                pDet = value;
            }
        }

        public int MAH
        {
            get { return mah; }
            set
            {
                mah = value;
            }
        }

        public int changeStrensth()
        {
            if(currentStrensth <= strensthMax)
            {
                currentStrensth += 1;
                Attack += currentStrensth * 5;
                HP += currentStrensth * 2;
            }
            return currentStrensth;
        }

        public int changeDesterity()
        {
            if (currentDesterity <= desterityMax)
            {
                currentDesterity += 1;
                Attack += currentDesterity * 1;
                PDet += currentDesterity * 1;
            }
            return currentDesterity;
        }

        public int changeConstitution()
        {
            if (currentConstitution <= constitutionMax)
            {
                currentConstitution += 1;
                HP += currentConstitution * 10;
                PDet += currentDesterity * 2;
            }
            return currentConstitution;
        }

        public int changeIntellisense()
        {
            if (currentIntellisense <= intellisenseMax)
            {
                currentIntellisense += 1;
                MP += currentIntellisense * 1;
                MAH += currentIntellisense * 1;
            }
            return currentIntellisense;
        }
    }
}
