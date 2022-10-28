using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units_Practic.Items.Helmets
{
    [BsonDiscriminator("IronHelmet")]
    public class IronHelmet : Helmet, IChangeStats, INecessaryCharacteristics
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

        public IronHelmet()
        {
            name = "Iron Helmet";

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
