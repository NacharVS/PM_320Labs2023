namespace WarCraft_3_ConsoleEdition
{
    public class Movable : Unit
    {
        public int Speed { get; set; }
        public Movable(int speed, int health, int cost, string name, int level)
            : base(health, cost, name, level)
        {
            this.Speed = speed;
        }
        void Move()
        {
        }     
    }
}
