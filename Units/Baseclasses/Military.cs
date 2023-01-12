// Turushkin Sergey, 320P, "Warcraft"

namespace Units.BaseClasses
{
    public abstract class Military : Moveble
    {
        public double damage;
        public double attackSpeed;
        public double armor;

        public Military(double health, double cost, string name, int lvl, double speed,
                        double damage, double attackSpeed, double armor)
                 : base(health, cost, name, lvl, speed)
        {
            this.damage = damage;
            this.attackSpeed = attackSpeed;
            this.armor = armor;
        }

        public abstract void Attack(Unit unt);
    }
}
