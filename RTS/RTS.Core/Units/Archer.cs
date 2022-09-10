using System;
using System.Threading;

namespace RTS.Core.Annotations.Units
{
    public class Archer : Military
    {
        public int ArrowCount;

        public Archer(int health, int cost, [CanBeNull] string? name, int level, int speed, int damage,
            int attackSpeed, int armor, int arrowCount) : base(health, cost, name, level, speed, damage, attackSpeed,
            armor)
        {
            ArrowCount = arrowCount;
        }

        public override void Attack(Unit entity)
        {
            if (entity.IsDestroyed)
            {
                Console.WriteLine("игрок помер");
            }

            Thread.Sleep(AttackSpeed);
            entity.DealingDamage(this);
        }
        public override void DealingDamage(Military entity)
        {
            Health -= entity.Damage > Armor ? entity.Damage : 0;
            ((Archer) entity).ArrowCount--;
            this.CheckIsDestroyed();
        }
    }
}