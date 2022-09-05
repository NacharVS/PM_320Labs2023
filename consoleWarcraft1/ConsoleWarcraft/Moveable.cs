using System;

namespace ConsoleWarcraft
{
    public class Moveable : Unit
    {
        public double speed = 0;
        
        public virtual void move()
        {
            Console.WriteLine("Moveable is move");
        }
    }
}