namespace WarCraft_3_ConsoleEdition
{
    class Movable : Unit
    {
        public int speed;
        void Move()
        {
        }

        public Movable(int speed, int health, int cost, string name, int level)
            : base(health, cost, name, level)
        {
            this.speed = speed;
        }
    }
}
