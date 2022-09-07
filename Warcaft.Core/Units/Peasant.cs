using Warcaft.Core.BaseEntities;

namespace Warcaft.Core.Units
{
    public class Peasant : Movable
    {
        public Peasant(int health, int cost, string? name, int level, int speed)
            : base(health, cost, name, level, speed)
        {
        }

        public void Mining() { }

        public void Chopping() { }
        public override void Move() { }
    }
}
