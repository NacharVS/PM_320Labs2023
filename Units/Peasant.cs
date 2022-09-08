// Turushkin Sergey, 320P, "Warcraft"

namespace Units
{
    public class Peasant : Moveble
    {
        public Peasant(double health, double cost, string name, int lvl, double speed) 
                : base(health, cost, name, lvl, speed)
        { }

        public void Mining()
        {
            spell.Mining();
        }

        public void Choping()
        {
            spell.Choping();
        }

        public override void Move()
        { 
            spell.Move();
        }

        public override void Attack(Unit unt)
        { }
    }
}
