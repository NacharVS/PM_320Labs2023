namespace WarCraft_3_ConsoleEdition
{
    class Peasant : Movable
    {
        void Mining() { }
        void Chopping() { }

        public Peasant(int speed, int health, int cost, string name, int level)
            : base(speed, health, cost, name, level)
        {
        }
    }
}
