using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Units_Practic.Abilities;
using Units_Practic.Items;

namespace Units_Practic.Characters
{
    public enum Units
    {
        Warrior,
        Rogue,
        Wizard
    }
    [BsonDiscriminator("Unit")]
    public class Unit
    {
        public ObjectId _id;

        public string name;
        public double healthPoint;
        public double manaPoint;
        public Characteristics characteristics;

        public Lvl lvl;
        public double atackPoint;
        public double physicalProtectionPoint;
        public double magicAtackPoint;

        public List<Item> inventory;

        public Unit()
        {
            lvl = new Lvl();
        }

        public override string ToString()
        {
            return name;
        }

        public void UpdateHaracteristics()
        {
            healthPoint = characteristics.HealthUpdate(characteristics.type);
            manaPoint = characteristics.ManaUpdate(characteristics.type);
            atackPoint = characteristics.AttackUpdate(characteristics.type);
            magicAtackPoint = characteristics.ManaAttackUpdate(characteristics.type);
            physicalProtectionPoint = characteristics.PhysicalProtectionUpdate(characteristics.type);
        }
    }
}