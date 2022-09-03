using System;


namespace Warcraft
{
    class Peasant : Moveble
    {

        public Peasant(int health, int cost, string name, int lvl, int speed,
                    int damage, int attackSpeed, int armor)
                    : base(health, cost, name, lvl, speed)
        {

        }

        public string GetName()
        {
            return base.GetName();
        }

        public void Mining()
        {
            Console.WriteLine("I am mining");
        }

        public void Choping()
        {
            Console.WriteLine("I am choping");
        }
    }
}
