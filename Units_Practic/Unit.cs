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
        public double lvl;
        public int boostPoints;
        public double atackPoint;
        public double physicalProtectionPoint;
        public double magicAtackPoint;

        public Unit()
        {
            lvl = 1;
            boostPoints = 5;
        }

        public void HealthUpdate()
        {

        }
    }
}