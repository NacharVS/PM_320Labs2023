namespace WarCraft_3_ConsoleEdition
{
    public class Unit
    {
        public int health;
        public int cost;
        public string name;
        public int level;
        public int timeWithoutAttack;

        public Unit(int health, int cost, string name, int level)
        {
            this.health = health;
            this.cost = cost;
            this.name = name;
            this.level = level;
        }
    }
}
