// Turushkin Sergey, 320P, "Warcraft"

namespace Units
{
    public class Footman : Military
    {
        public Footman(double health, double cost, string name, double speed,
                       double damage, double attackSpeed, double armor)
                       : base(health, cost, name, speed, damage, attackSpeed, armor) { }

        public override void Attack(Unit unt)
        {
            unt.health -= damage;

            if (unt.health <= 0)
            {
                unt.isDestroyed = true;
                unt.health = 0;
            }
        }

        public void Berserker()
        {

        }

        public override void Move()
        {

        }

        public void Stun()
        {

        }
    }
}
