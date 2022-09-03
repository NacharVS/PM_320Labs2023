using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWarcraftProj
{
    class Military : Moveable
    {
        public int Damage { get; set; }
        public int AttackSpeed { get; set; }
        public int Armor { get; set; }

        public Military(string name, int health, 
            int cost, int lvl, bool isDestroyed, 
            int speed, int damage, int attackSpeed, 
            int armor) : base(name, health, cost, 
                lvl, isDestroyed, speed)
        {
            this.Damage = damage;
            this.AttackSpeed = attackSpeed;
            this.Armor = armor;
        }

        public void Attack() { }
    }
}
