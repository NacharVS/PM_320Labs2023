using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarcraftLibrary
{
    public class Unit
    {
        public string Name;
        public int Health;
        public int Cost;
        public int Lvl;
        public bool IsDestroyed;
        public int Damage;

        public Unit(string name, int health, int cost, int lvl, bool isDestroyed, int damage)
        {
            this.Name = name;
            this.Health = health;
            this.Cost = cost;
            this.Lvl = lvl;
            this.IsDestroyed = isDestroyed;
            this.Damage = damage;
        }

        public virtual string Attack(int num)
        {
            return " ";
        }

        public void Checking()
        {
            if (Health <= 0)
            {
                IsDestroyed = true;
            }
        }
    }
}
