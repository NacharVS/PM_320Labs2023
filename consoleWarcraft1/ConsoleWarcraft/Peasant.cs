using System;

namespace ConsoleWarcraft
{
    public class Peasant : Moveable
    {

        public override void move()
        {
            Console.WriteLine("Peasant is attack");
        }

        public void mining()
        {
            Console.WriteLine("Peasant is minig");
        }

        public void choping()
        {
            Console.WriteLine("Peasant is choping");
        }
    }

}