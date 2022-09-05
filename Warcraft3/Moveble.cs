using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warcraft3
{
    internal class Moveble:Unit
    {
        int speed;

        public Moveble()
        {
        }

        public Moveble(string name, int health, int cost, int lvl, int maxHP,int speed) : base(name, health, cost, lvl, maxHP)
        {
            this.speed = speed;
        }


        public virtual void Move() 
        {
            Console.WriteLine("I'm moving");
        }
    }
}
