namespace WarCraft_3_ConsoleEdition
{
    class Range : Military
    {
        public int range;
        public int mana;

        public Range(int range, int mana, int damage, int attackSpeed,
            int armor, int speed, int health, int cost, string name, int level)
           : base(damage, attackSpeed, armor, speed, health, cost, name, level)
        {
            this.range = range;
            this.mana = mana;
        }

        protected void ReportingLackOfMana()
        {
            Console.WriteLine("Not enough mana!");
        }
    }

}
