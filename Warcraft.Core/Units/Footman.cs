using Warcraft.Core.BaseEntities;

namespace Warcraft.Core.Units
{
    public class Footman : Military
    {

        public void Rage()
        {
            AttackSpeed = AttackSpeed / 2;
        }

        public void Stun() { }

        public override void Attack(Unit unit) { }

        public override void Move() { }

        public Footman(int health, int cost, string? name, int level, int speed, int damage, int attackSpeed, int armor)
            : base(health, cost, name, level, speed, damage, attackSpeed, armor)
        {
        }
    }
}
