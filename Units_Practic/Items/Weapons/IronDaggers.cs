using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units_Practic.Items.Weapons
{
    public class IronDaggers : Weapon, IChangeStats, INecessaryCharacteristics
    {
        public double healthPointChange { get; init; }
        public double manaPointChange { get; init; }
        public double atackPointChange { get; init; }
        public double physicalProtectionPointChange { get; init; }
        public double magicAtackPointChange { get; init; }

        public int necessaryStrength { get; init; }
        public int necessaryDexterity { get; init; }
        public int necessaryConstitution { get; init; }
        public int necessaryIntelligence { get; init; }

        public IronDaggers()
        {
            name = "Iron Daggers";

            healthPointChange = 0;
            manaPointChange = 0;
            atackPointChange = 65;
            physicalProtectionPointChange = 0;
            magicAtackPointChange = 0;

            necessaryStrength = 30;
            necessaryDexterity = 40;
            necessaryConstitution = 25;
            necessaryIntelligence = 15;
        }
    }
}
