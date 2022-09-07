using System;

namespace WarCraft_3_ConsoleEdition
{
    public class Military : Movable
    {
        public int Damage { get; set; }
        public int AttackSpeed { get; set; }
        public int Armor { get; set; }

        public delegate void AttackDelegate(Unit unit);

        public Military(int damage, int attackSpeed, int armor,
            int speed, int health, int cost, string name, int level)
            : base(speed, health, cost, name, level)
        {
            this.Damage = damage;
            this.AttackSpeed = attackSpeed;
            this.Armor = armor;
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
