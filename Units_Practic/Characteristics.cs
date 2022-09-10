using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units_Practic
{
    public class Characteristics
    {
        double strength;
        int strenghtMax;
        int strenghtMin;

        double dexterity;
        int dexterityMax;
        int dexterityMin;

        double constitution;
        int constitutionMax;
        int constitutionMin;

        double intelligence;
        int intelligenceMax;
        int intelligenceMin;

        public Characteristics(Units unt)
        {
            switch (unt)
            {
                case Units.Warrior:
                    strenghtMax = 250;
                    strenghtMin = 30;

                    dexterity = 15;
                    dexterityMax = 70;
                    dexterityMin = 15;

                    constitutionMax = 100;
                    constitutionMin = 20;

                    intelligenceMax = 50;
                    intelligenceMin = 10;
                break;

                case Units.Rogue:
                    strenghtMax = 55;
                    strenghtMin = 15;

                    dexterityMax = 250;
                    dexterityMin = 30;

                    constitutionMax = 80;
                    constitutionMin = 20;

                    intelligenceMax = 70;
                    intelligenceMin = 15;
                break;

                case Units.Wizard:
                    strenghtMax = 45;
                    strenghtMin = 10;

                    dexterityMax = 70;
                    dexterityMin = 20;

                    constitutionMax = 60;
                    constitutionMin = 15;

                    intelligenceMax = 250;
                    intelligenceMin = 35;
                break;

                default:
                    throw new Exception("Unknown unit");
                break;
            }

            strength = strenghtMin;
            dexterity = dexterityMin;
            constitution = constitutionMin;
            intelligence = intelligenceMin;
        }

        public void HealthUpdate()
        {

        }
    }
}
