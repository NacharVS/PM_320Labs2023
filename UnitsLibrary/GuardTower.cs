using System;

namespace WarCraft_3_ConsoleEdition
{
    public class GuardTower : Unit
    {
        public int Range { get; set; }
        public int Damage { get; set; }
        public int AttackSpeed { get; set; }

        public delegate void AttackDelegate(Unit unit);

        public GuardTower(int range, int damage, int attackSpeed,
            int health, int cost, string name, int level) : base(health, cost, name, level)
        {
            this.Range = range;
            this.Damage = damage;
            this.AttackSpeed = attackSpeed;
        }

        public void Attack(Unit unit)
        {
            unit.Health -= DamageCalculating(unit);
            AttackEvent?.Invoke(unit);      
        }

        public void ReportDamage(Unit unit)
        {
                Console.WriteLine($"{Name} dealt {DamageCalculating(unit)} " +
                    $"damage to {unit.Name}");
        }

        private int DamageCalculating(Unit unit)
        {
            try
            {
                return (int)(this.Damage - this.Damage 
                * (double)((Military)unit).Armor / 100);
            }
            catch
            {
                return Damage;
            }
        }

        public event AttackDelegate AttackEvent;
    }
}
