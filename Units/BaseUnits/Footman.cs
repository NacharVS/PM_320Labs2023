// Turushkin Sergey, 320P, "Warcraft"

using Units.BaseClasses;

namespace Units.BaseUnits
{
    public class Footman : Military
    {
        public Footman(double health, double cost, string name, int lvl, double speed,
                       double damage, double attackSpeed, double armor)
                : base(health, cost, name, lvl, speed, damage, attackSpeed, armor) { }

        public override void Attack(Unit unt)
        {
            action.Attack(unt, damage);
        }

        public void Berserker()
        {
            action.Berserker();
        }

        public override void Move()
        {
            action.Move();
        }

        public void Stun()
        {
            action.Stun();
        }
    }
}
