using System;

namespace WarCraft_3_ConsoleEdition
{
    public class Mage : Range
    {
        public void Fireball(Unit unit)
        {
            if (this.Mana >= 20)
            {
                unit.Health -= this.Damage * 2;
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
            }

            else
            {
                ReportingLackOfMana();
            }
        }

        public int Heal(Unit unit)
        {
            private int hp;

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
            }

            return hp;
        }

        public Mage(int range, int mana, int damage, int attackSpeed, int armor,
            int speed, int health, int cost, string name, int level) : base(range,
                mana, damage, attackSpeed, armor, speed, health, cost, name, level)
        {
        }
    }
}
