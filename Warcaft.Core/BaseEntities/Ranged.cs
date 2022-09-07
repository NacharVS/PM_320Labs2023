namespace Warcaft.Core.BaseEntities
{
    public abstract class Ranged : Military
    {
        public int Range  { get; private protected set; }

        public int Mana  { get; private protected set; }

        protected Ranged(int health, int cost, string? name, int level, int speed, int damage, int attackSpeed,
            int armor, int range, int mana)
            : base(health, cost, name, level, speed, damage, attackSpeed, armor)
        {
            Range = range;
            Mana = mana;
        }
    }
}
