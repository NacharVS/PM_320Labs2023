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
            spell.FireBall();
        }

        public void Blizzard() 
        {
            spell.Blizzard();
        }

        public void Heal(Unit unt) 
        {
            spell.Heal(unt);
        }

        public override void Attack(Unit unt)
        {
            spell.Attack(unt, damage);
        }

        public override void Move() 
        {
            spell.Move();
        }
    }
}
