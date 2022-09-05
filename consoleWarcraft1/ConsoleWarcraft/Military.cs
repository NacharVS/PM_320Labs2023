using System;

namespace ConsoleWarcraft
{
    public class Military : Moveable
    {
        public double damage = 10;
        public int attackSpeed = 0;
        public int armor = 2;

        public virtual void attack(Unit unit)
        {
            
        }

        public override void move()
        {
            Console.WriteLine("Military is move");
        }
    }
}