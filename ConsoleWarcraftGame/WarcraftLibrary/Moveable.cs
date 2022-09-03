using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarcraftLibrary
{
    public class Moveable : Unit
    {
        public int Speed;

        public Moveable(string name, int health, int cost, int lvl, bool isDestroyed, int speed, int damage) : base(name, health, cost, lvl, isDestroyed, damage)
        {
            this.Speed = speed;
        }

        public void Move() {}
    }
}
