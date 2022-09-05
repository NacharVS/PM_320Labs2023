using System;

namespace ConsoleWarcraft
{
    public class Unit {

        public String name = "Hero1";
        public double health = 100;
        public int cost = 0;
        public int level = 0;
        public bool isDestroy = false;

        public virtual bool isDestroyed()
        {
            if (health < 0)
            {
                isDestroy = true;
                return isDestroy;
            }
            return isDestroy;
        }
    }
}