using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units_Practic.Items.Helmets
{
    public class RogueGuildHood : Helmet, IChangeStats, INecessaryCharacteristics
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

        public RogueGuildHood()
        {
            name = "Rogue Guild Hood";

            healthPointChange = 15;
            manaPointChange = 0;
            atackPointChange = 35;
            physicalProtectionPointChange = 10;
            magicAtackPointChange = 0;

            necessaryStrength = 15;
            necessaryDexterity = 40;
            necessaryConstitution = 20;
            necessaryIntelligence = 15;
        }
    }
}
