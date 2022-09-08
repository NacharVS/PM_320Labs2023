// Turushkin Sergey, 320P, "Warcraft"

namespace Units
{
    public class Mage : Range
    {
        public Mage(double health, double cost, string name, int lvl, double speed,
                    double damage, double attackSpeed, double armor, double range, double mana)
                    : base(health, cost, name, lvl, speed, damage, attackSpeed, armor, range, mana) { }

        public void FireBall() 
        {
            action.FireBall();
        }

        public void Blizzard() 
        {
            action.Blizzard();
        }

        public void Heal(Unit unt) 
        {
            action.Heal(unt);
        }

        public override void Attack(Unit unt)
        {
            action.Attack(unt, damage);
        }

        public override void Move() 
        {
            action.Move();
        }
    }
}
