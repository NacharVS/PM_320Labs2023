using Warcraft.Core.BaseEntities;

namespace Warcraft.Core.Units
{
    public class Peasant : Movable
    {

        public int MiningSpeed { get; private set; }
        public int ChoppingSpeed { get; private set; }

        public Peasant(int health, int cost, string? name, int level, int speed)
            : base(health, cost, name, level, speed)
        {
            MiningSpeed = 3500;
            ChoppingSpeed = 3500;
        }

        public void Mining()
        {
            Console.WriteLine("Peasant is mining.....");
            Thread.Sleep(MiningSpeed);
            Console.WriteLine("Mining is done!");
        }

        public void Chopping()
        {
            Console.WriteLine("Peasant is chopping.....");
            Thread.Sleep(ChoppingSpeed);
            Console.WriteLine("Chopping is done!");
        }
        public override void Move() { }
    }
}
