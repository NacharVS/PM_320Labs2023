namespace WarCraft_3_ConsoleEdition
{
    public class Peasant : Movable
    {
        public Peasant(int speed, int health, int cost, string name, int level)
            : base(speed, health, cost, name, level)
        {
        }

        void Mining() { }
        void Chopping() { } 
    }
}
