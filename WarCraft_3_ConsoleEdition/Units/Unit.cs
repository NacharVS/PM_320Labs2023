namespace WarCraft_3_ConsoleEdition
{
    public class Unit
    {
        public int Health { get; set; }
        public int Cost { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int TimeWithoutAttack { get; set; }

        public Unit(int health, int cost, string name, int level)
        {
            this.Health = health;
            this.Cost = cost;
            this.Name = name;
            this.Level = level;
        }
    }
}
