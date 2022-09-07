// Turushkin Sergey, 320P, "Warcraft"

namespace Units
{
    public abstract class Range : Military
    {
        public double range;
        public double mana;

        public Range(double health, double cost, string name, int lvl, double speed,
                     double damage, double attackSpeed, double armor, double range, double mana)
              : base(health, cost, name, lvl, speed, damage, attackSpeed, armor)
        {
            this.range = range;
            this.mana = mana;
        }
    }
}
