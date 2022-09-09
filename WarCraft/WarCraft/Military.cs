using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarCraft
{
    class Military : Moveable
    {
        public int Damage { get; set; }
        public int AttackSpeed { get; set; }
        public int Armor { get; set; }

        public Military(string name, int health, 
            int cost, int speed, int damage, 
            int attackSpeed, int armor) : 
            base(name, health, cost, speed)
        {
            this.Damage = damage;
            this.AttackSpeed = attackSpeed;
            this.Armor = armor;
        }

        public virtual string Attack(int number, Military player1, Military player2) 
        {
            return $"Attack";
        }
    }
}
