using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units_Practic.Items.Helmets
{
    public class ScientistTiara : Item, IHelmet, IChangeStats, INecessaryCharacteristics
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

        public ScientistTiara()
        {
            name = "Scientist Tiara";

            healthPointChange = 0;
            manaPointChange = 250;
            atackPointChange = 0;
            physicalProtectionPointChange = 10;
            magicAtackPointChange = 500;

            necessaryStrength = 10;
            necessaryDexterity = 10;
            necessaryConstitution = 20;
            necessaryIntelligence = 50;
        }
    }
}
