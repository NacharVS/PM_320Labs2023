// Turushkin Sergey, 320P, "Warcraft"

namespace Units
{
    public class Footman : Military
    {
        public Footman(double health, double cost, string name, int lvl, double speed,
                       double damage, double attackSpeed, double armor)
                : base(health, cost, name, lvl, speed, damage, attackSpeed, armor) { }

        public override void Attack(Unit unt)
        {
            spell.Attack(unt, damage);
        }

        public void Berserker() 
        {
            spell.Berserker();
        }

        public override void Move()
        {
            spell.Move();
        }

        public void Stun()
        {
            spell.Stun();
        }
    }
}
