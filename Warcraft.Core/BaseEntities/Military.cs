namespace Warcraft.Core.BaseEntities
{
    public abstract class Military : Movable
    {
        public int Damage { get; private protected set; }

        public int AttackSpeed  { get; private protected set; }
    
        public int Armor  { get; private protected set; }

        protected Military(int health, int cost, string? name, int level, int speed, 
            int damage, int attackSpeed, int armor)
            : base(health, cost, name, level, speed)
        {
            Damage = damage;
            AttackSpeed = attackSpeed;
            Armor = armor;
        }
        
        public abstract void Attack(Unit unit);
    }
}
