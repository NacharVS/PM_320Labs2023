using System;

namespace WarCraft_3_ConsoleEdition
{
    public class Mage : Range
    {
        public void Fireball(Unit unit)
        {
            if (this.mana >= 20)
            {
                unit.health -= this.damage * 2;
            }

            else
            {
                ReportingLackOfMana();
            }
        }

        public void Blizzard(Unit unit)
        {
            if (this.mana >= 15)
            {
                unit.timeWithoutAttack += 7;
                mana -= 15;
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

            if (hp * 5 <= this.mana)
            {
                unit.health += hp;
                this.mana -= hp * 5;
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
