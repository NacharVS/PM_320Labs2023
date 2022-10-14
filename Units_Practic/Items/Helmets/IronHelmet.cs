using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units_Practic.Items.Helmets
{
    public class IronHelmet : Item, IHelmet, IChangeStats, INecessaryCharacteristics
    {
        public double healthPointChange { get ; init ; }
        public double manaPointChange { get; init; }
        public double atackPointChange { get; init; }
        public double physicalProtectionPointChange { get; init; }
        public double magicAtackPointChange { get; init; }

        public int necessaryStrength { get; init; }
        public int necessaryDexterity { get; init; }
        public int necessaryConstitution { get; init; }
        public int necessaryIntelligence { get; init; }

        public IronHelmet(string name) : base(name) 
        {
            healthPointChange = 30;
            manaPointChange = 0 ;
            atackPointChange = 0 ;
            physicalProtectionPointChange = 1500;
            magicAtackPointChange = 0;

            necessaryStrength = 30;
            necessaryDexterity= 15;
            necessaryConstitution = 20;
            necessaryIntelligence = 10;
        }
    }
}
