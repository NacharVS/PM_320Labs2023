// Turushkin Sergey, 320P, "Warcraft"

namespace Units
{
    public abstract class Military : Moveble
    {
        public double damage;
        public double attackSpeed;
        public double armor;

        public Military(double health, double cost, string name, double speed, 
                        double damage, double attackSpeed, double armor) : base(health, cost, name, speed)
        {
            this.damage = damage;
            this.attackSpeed = attackSpeed;
            this.armor = armor;
        }
    }
}
