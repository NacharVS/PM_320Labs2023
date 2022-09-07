namespace Warcraft.Core.BaseEntities
{
     public abstract class Unit 
    {
        public int Health { get; private protected set; }
        public int Cost { get; private protected set; }
        public string? Name { get; private protected set; }
        public int Level { get; private protected set; }
        public bool IsDestroyed { get; private protected set; }
        public int MaxHealth { get; private protected set; }

        protected Unit(int health, int cost, string? name, int level)
        {
            Health = health;
            Cost = cost;
            Name = name;
            Level = level;
            IsDestroyed = false;
            MaxHealth = health;
        }
    }
}
