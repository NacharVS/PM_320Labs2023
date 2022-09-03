using System;


namespace Warcraft
{
    class Unit
    {
        public Random rnd = new Random();
        int health;
        int cost;
        string name;
        int lvl;
        bool isDestroyed = false;

        public Unit(int health, int cost, string name, int lvl)
        {
            this.health = health;
            this.cost = cost;
            this.name = name;
            this.lvl = lvl;
        }

        public bool GetIsDestroyed()
        {
            return isDestroyed;
        }

        public void SetIsDestroyed()
        {
            this.isDestroyed = true;
        }

        public int GetHealth()
        {
            return health;
        }

        public void SetHealth(int health)
        {
            this.health = health;
        }

        public string GetName()
        {
            return name;
        }
    }
}
