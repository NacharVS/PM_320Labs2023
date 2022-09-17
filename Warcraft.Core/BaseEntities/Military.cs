using Warcraft.Core.EventArgs;

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

        private protected void Attack(Unit unit, int damage)
        {
            if (unit.IsDestroyed || IsDestroyed)
                return;
            
            Thread.Sleep(AttackSpeed);
            
            if (unit.IsDestroyed || IsDestroyed)
                return;

            Console.WriteLine($"{Name} chose target {unit.Name}");
            unit.GetDamage(damage);
        }

        public void Attack(Unit unit)
        {
            Attack(unit, Damage);
        }

        public new void GetDamage(int damage)
        {
            RaiseOnHitEvent(this, new HitArgs(damage < Armor ? damage - Armor : 0, Health));
        }

        public void UpgradeWeapon(int point)
        {
            Damage += point;
        }

        public void UpgradeArmor(int point)
        {
            Armor += point;
        }
    }
}
