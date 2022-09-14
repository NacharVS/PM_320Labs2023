using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warcraft3
{
    internal class Unit
    {
        
        string name = "";
        double health;
        int cost;
        int lvl;
        int maxHP;
        bool isDestroyed;

        public Unit(string name, int health, int cost,int lvl, int maxHP)
        {
            this.name = name;
            this.health = health;
            this.cost = cost;
            this.lvl = lvl;
            this.maxHP = maxHP;
        }
        public Unit()
        {

        }


        public virtual void SetHealth(double health)
        {
            if (health <= 0)
            {
                this.health = 0;
                isDestroyed = true;
            }
            else
            {
                this.health = health;
            }
            
        }


        public bool isDeath()
        {
            if(isDestroyed)
            {
                Console.WriteLine("DEATH " + name);
                return true;
            }
            return false;
        }

        public double GetHealth()
        {
            return health;
        }
        public int GetLvl()
        {
            return lvl;
        }
        public string GetName()
        {
            return name;
        }
        public bool GetIsDestroyed()
        {
            return isDestroyed;
        }


    }
}
