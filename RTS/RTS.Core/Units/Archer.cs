namespace RTS.Core.Annotations.Units
{
    public class Archer : Military
    {
        public int ArrowCount;
        
        public Archer(int health, int cost, [CanBeNull] string? name, int level, int speed, int damage,
            int attackSpeed, int armor, int arrowCount) : base(health, cost, name, level, speed, damage, attackSpeed, armor)
        {
            ArrowCount = arrowCount;
        }
        
        public override void DealingDamage(ref Unit entity)
        {
            Health -= ((Archer)entity).Damage;
            ((Archer) entity).ArrowCount--;
        }
    }
}