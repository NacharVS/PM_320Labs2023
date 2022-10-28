using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units_Practic.Items.ChestArmors
{
    [BsonDiscriminator("GuildMasterArmor")]
    public class GuildMasterArmor : ChestArmor, IChangeStats, INecessaryCharacteristics
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

        public GuildMasterArmor()
        {
            name = "Guild Master's Armor";

            healthPointChange = 0;
            manaPointChange = 550;
            atackPointChange = 0;
            physicalProtectionPointChange = 10;
            magicAtackPointChange = 250;

            necessaryStrength = 10;
            necessaryDexterity = 25;
            necessaryConstitution = 20;
            necessaryIntelligence = 55;
        }
    }
}
