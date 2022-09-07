// Turushkin Sergey, 320P, "Warcraft"

namespace Units
{
    public class Mage : Range
    {
        public Mage(double health, double cost, string name, int lvl, double speed,
                    double damage, double attackSpeed, double armor, double range, double mana)
                    : base(health, cost, name, lvl, speed, damage, attackSpeed, armor, range, mana) { }

        public void FireBall() { }

        public void Blizzard() { }

        public void Heal(Unit unt) 
        {
            unt.health += (lvl * 0.1) * mana;
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

        public override void Move() { }
    }
}
