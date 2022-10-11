using MongoDB.Bson;
using Units_Practic.Abilities;

namespace Units_Practic.Characters
{
    public enum Units
    {
        Warrior,
        Rogue,
        Wizard
    }

    public abstract class Unit
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