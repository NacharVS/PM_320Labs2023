namespace Units_Practic
{
    public enum Units
    {
        Warrior,
        Rogue,
        Wizard
    }

    public abstract class Unit
    {
        public double healthPoint;
        public double manaPoint;
        public Characteristics characteristics;
        public Lvl lvl;
        //public double lvl;
        //public int boostPoints;
        public double atackPoint;
        public double physicalProtectionPoint;
        public double magicAtackPoint;

        public Unit()
        {
            lvl = new Lvl();
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