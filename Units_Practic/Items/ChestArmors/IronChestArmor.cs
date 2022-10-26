using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units_Practic.Items.ChestArmors
{
    public class IronChestArmor : Item, IChestArmor, IChangeStats, INecessaryCharacteristics
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

        public IronChestArmor()
        {
            name = "Iron Chest Armor";

            healthPointChange = 50;
            manaPointChange = 0;
            atackPointChange = -5;
            physicalProtectionPointChange = 2500;
            magicAtackPointChange = 0;

            necessaryStrength = 50;
            necessaryDexterity = 25;
            necessaryConstitution = 25;
            necessaryIntelligence = 10;
        }
    }
}
