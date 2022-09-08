using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warcraft3
{
    internal class Dragon:Range
    {
        public Dragon(string name, int health, int cost, int lvl, int maxHP, int speed, int damage, int attackSpeed,
           int armor) : base(name, health, cost, lvl, maxHP, speed, damage, attackSpeed, armor)
        {

        }
        public Dragon(string name,int damage,int health,int maxHealth):base(name,health)
        {

        }
        public void FireBreath(Unit unit) 
        {
            unit.SetHealth(unit.GetHealth() - this.GetDamage() * 5);
            PrintForFire(unit);
        }
        protected virtual void PrintForFire(Unit unit)
        {
            Console.WriteLine($"{this.GetName()} attack {unit.GetName()} for " +
                $"{IncreasedAtttack(this.GetLvl()) * 5}. {unit.GetName()} HP - {unit.GetHealth()}");
        }
    }
}
