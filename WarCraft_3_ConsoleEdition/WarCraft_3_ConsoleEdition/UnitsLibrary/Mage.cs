using System;

namespace WarCraft_3_ConsoleEdition
{
    public class Mage : Range
    {
        public int BlizzardTime { get; private set; } = 7;

        public Mage(int range, int mana, int damage, int attackSpeed, int armor,
            int speed, int health, int cost, string name, int level) : base(range,
                mana, damage, attackSpeed, armor, speed, health, cost, name, level)
        {
        }

        public void Fireball(Unit unit)
        {
            if (this.Mana >= 20)
            {
                unit.Health -= this.Damage * 2;
                FireballReport(unit);
            }

            else
            {
                ReportingLackOfMana();
            }
        }

        public void Blizzard(Unit unit)
        {
            if (this.Mana >= 15)
            {
                unit.TimeWithoutAttack += 7;
                this.Mana -= 15;
                BlizzardReport(unit);
            }

            else
            {
                ReportingLackOfMana();
            }
        }

        public int Heal(Unit unit)
        {
            int hp;

            Console.Write("Enter the number of HP: ");
            hp = int.Parse(Console.ReadLine());

            if (hp * 5 <= this.Mana)
            {
                unit.Health += hp;
                this.Mana -= hp * 5;
            }

            else
            {
                ReportingLackOfMana();
                hp = 0;
            }

            return hp;
        }

        private void FireballReport(Unit unit)
        {
            Console.WriteLine($"{Name} used fireball " +
                                $"and dealt {Damage * 2} " +
                                $"damage to {unit.Name}");
        }

        private void BlizzardReport(Unit unit)
        {
            Console.WriteLine($"{Name} froze " +
                           $"{unit.Name} for {BlizzardTime} second");
        }
    }
}
