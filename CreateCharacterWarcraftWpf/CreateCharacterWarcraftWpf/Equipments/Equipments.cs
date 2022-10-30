using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateCharacterWarcraftWpf.Equipments
{
    [BsonKnownTypes(typeof(WoodenSword), typeof(IronSword),
        typeof(ObsidianSword), typeof(WoodenHelmet), typeof(IronHelmet),
        typeof(ObsidianHelmet), typeof(WoodenArmor), typeof(IronArmor),
        typeof(ObsidianArmor))]
    public class Equipments
    {
        [BsonId]
        public ObjectId equipment_id;

        public int ReqStrength { get; set; }

        public int ReqDexterity { get; set; }

        public int ReqConstitution { get; set; }

        public int ReqIntelligence { get; set; }

        public int StrengthBuff { get; set; }

        public int DexterityBuff { get; set; }

        public int ConstitutionBuff { get; set; }

        public int IntelligenceBuff { get; set; }

        public int HealthPointsBuff { get; set; }

        public int ManaPointsBuff { get; set; }

        public int AttackBuff { get; set; }

        public int EquipmentLevel { get; set; }

        public string EquipmentName { get; set; }

        public string EquipmentType { get; set; }

        public override string ToString()
        {
            return $"{EquipmentName} : {EquipmentLevel}";
        }
        public override bool Equals(object? obj)
        {
            return this.EquipmentName == (obj as Equipments).EquipmentName;
        }
    }
}
