// Turushkin Sergey, 320P, "Warcraft"

namespace Units
{
    public abstract class Moveble : Unit
    {
        public double speed;

        public Moveble(double health, double cost, string name, double speed) : base(health, cost, name)
        {
            this.speed = speed;
        }

        public abstract void Move();
    }
}
