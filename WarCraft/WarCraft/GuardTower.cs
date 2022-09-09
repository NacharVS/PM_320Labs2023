using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarCraft
{
    class GuardTower : Unit
    {
        public int Range { get; set; }
        public int Damage { get; set; }
        public int AttackSpeed { get; set; }

        public GuardTower(string name, int health, int cost, 
            int range, int damage, int attackSpeed) : 
            base(name, health, cost)
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
