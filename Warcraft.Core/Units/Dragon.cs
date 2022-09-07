using Warcraft.Core.BaseEntities;

namespace Warcraft.Core.Units
{
    public class Dragon : Ranged
    {
        public override void Attack(Unit unit) { }

        public void FireBreath() { }

        public override void Move() { }

        public Dragon(int health, int cost, string? name, int level, int speed, int damage,
            int attackSpeed, int armor, int range, int mana) 
            : base(health, cost, name, level, speed, damage, attackSpeed, armor, range, mana)
        {
        }
    }
}
