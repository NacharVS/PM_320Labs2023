using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWarcraft.enumUnits
{
    public class Warrer
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
    
        public Warrer()
        {

        }

        public int changeStrensth()
        {
            if(currentStrensth < strensthMax)
            {
                currentStrensth += 1;
            }
            return currentStrensth;
        }

        public int changeDesterity()
        {
            return 0;
        }

        public int changeConstitution()
        {
            return 0;
        }

        public int changeIntellisense()
        {
            return 0;
        }
    }
}
