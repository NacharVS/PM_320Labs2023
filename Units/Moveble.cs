// Turushkin Sergey, 320P, "Warcraft"

namespace Units
{
    public abstract class Moveble : Unit
    {
        public double speed;

        public Moveble(double health, double cost, string name, int lvl, double speed) : base(health, cost, name, lvl)
        {
            this.speed = speed;
        }

        public abstract void Move();
    }
}
