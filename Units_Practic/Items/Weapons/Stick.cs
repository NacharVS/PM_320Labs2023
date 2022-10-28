using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units_Practic.Items.Weapons
{
    public class Stick : Weapon, IChangeStats, INecessaryCharacteristics
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

        public Stick()
        {
            name = "Stick";

            healthPointChange = 5;
            manaPointChange = 50;
            atackPointChange = 0;
            physicalProtectionPointChange = 0;
            magicAtackPointChange = 80;

            necessaryStrength = 10;
            necessaryDexterity = 20;
            necessaryConstitution = 20;
            necessaryIntelligence = 45;
        }
    }
}
