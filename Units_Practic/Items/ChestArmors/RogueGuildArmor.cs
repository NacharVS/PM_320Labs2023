using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units_Practic.Items.ChestArmors
{
    public class RogueGuildArmor : ChestArmor, IChangeStats, INecessaryCharacteristics
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

        public RogueGuildArmor()
        {
            name = "Rogue Guild Armor";

            healthPointChange = 35;
            manaPointChange = 10;
            atackPointChange = 15;
            physicalProtectionPointChange = 10;
            magicAtackPointChange = 0;

            necessaryStrength = 25;
            necessaryDexterity = 45;
            necessaryConstitution = 25;
            necessaryIntelligence = 15;
        }
    }
}
