
using Units.BaseClasses;

namespace Units.BaseUnits
{
    public class Archer : BaseClasses.Range
    {
        public int arrowCount;

        public Archer(double health, double cost, string name, int lvl, double speed,
                      double damage, double attackSpeed, double armor, double range,
                      double mana, int arrowCount)
               : base(health, cost, name, lvl, speed, damage, attackSpeed, armor, range, mana) 
        {
            this.arrowCount = arrowCount;
        }

        public override void Attack(Unit unt)
        {
            if (arrowCount > 0)
            {
                action.Attack(unt, damage);
                -- arrowCount;
            }
        }

        public override void Move()
        {
            action.Move();
        }
    }
}
