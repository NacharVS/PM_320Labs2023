using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWarcraftProj
{
    class GuardTower : Unit
    {
        public int Range = 70;
        public int Damage = 25;
        public int AttackSpeed;

        public GuardTower(string name, int health,
            int cost, int lvl, bool isDestroyed, 
            int range, int damage, int attackSpeed) :
            base(name, health, cost, lvl, isDestroyed)
        {
            this.Range = range;
            this.Damage = damage;
            this.AttackSpeed = attackSpeed;
        }

        public string Attack() 
        {
            return $"Attack";
        }
    }
}
