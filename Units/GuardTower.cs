// Turushkin Sergey, 320P, "Warcraft"

namespace Units
{
    public class GuardTower : Unit
    {
        public double range;
        public double damage;
        public double attackSpeed;

        public GuardTower(double health, double cost, string name, int lvl, double range, double damage, double attackSpeed) : base(health, cost, name, lvl)
        {
            this.range = range;
            this.damage = damage;
            this.attackSpeed = attackSpeed;
        }

        public override void Attack(Unit unt) 
        {
            unt.health -= damage;

            if (unt.health <= 0)
            {
                unt.isDestroyed = true;
                unt.health = 0;
            }
        }
    }
}
