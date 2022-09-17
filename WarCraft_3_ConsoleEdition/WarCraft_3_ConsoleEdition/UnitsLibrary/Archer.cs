namespace WarCraft_3_ConsoleEdition
{
    public class Archer : Range
    {
        public int ArrowCount {get; set;}
        public Archer(int range, int damage, int attackSpeed, int arrowCount,
            int armor, int speed, int health, int cost, string name, int level)
           : base(range, 0, damage, attackSpeed, armor, speed, health, cost, name, level)
        {
            this.ArrowCount = arrowCount;
        }
    }
}
