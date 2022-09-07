using System;

namespace WarCraft_3_ConsoleEdition
{
    public class Range : Military
    {
        public int Distance { get; set;}
        public int Mana { get; set;}

        public Range(int range, int mana, int damage, int attackSpeed,
            int armor, int speed, int health, int cost, string name, int level)
           : base(damage, attackSpeed, armor, speed, health, cost, name, level)
        {
            this.Distance = range;
            this.Mana = mana;
        }

        protected void ReportingLackOfMana()
        {
            Console.WriteLine("Not enough mana!");
        }

    }
}
