using Warcaft.Core.BaseEntities;

namespace Warcaft.Core.Units
{
    public class GuardTower : Unit
    {
        public int Range { get; private protected set; }

        public int Damage { get; private protected set; }

        public int AttackSpeed { get; private protected set; }

        public void Attack(Unit unit) 
        {

        }

        public GuardTower(int health, int cost, string? name, int level, int range, int damage, int attackSpeed)
            : base(health, cost, name, level)
        {
            Range = range;
            Damage = damage;
            AttackSpeed = attackSpeed;
        }
    }
}
