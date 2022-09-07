// Turushkin Sergey, 320P, "Warcraft"

namespace Units
{
    public class Dragon : Range
    {
        public Dragon(double health, double cost, string name, int lvl, double speed,
                      double damage, double attackSpeed, double armor, double range, double mana)
               : base(health, cost, name, lvl, speed, damage, attackSpeed, armor, range, mana) { }

        public override void Attack(Unit unt)
        {
            unt.health -= damage;

            if (unt.health <= 0)
            {
                unt.isDestroyed = true;
                unt.health = 0;
            }
        }

        public void FireBreath() { }

        public override void Move() { }
    }
}
