using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warcraft3
{
    internal class GuardTower:Unit
    {
        int range;
        public int damage;
        public int attackSpeed;
        public GuardTower(string name, int health, int cost, int lvl, int maxHP) : base(name, health, cost, lvl, maxHP)
        {
           
        }
        public GuardTower()
        {

        }
        public int IncreasedAtttack(int lvl)
        {
            switch (lvl)
            {
                case 1:
                    damage += 5;
                    return damage;
                case 2:
                    damage += 5;
                    return damage;
                case 3:
                    damage += 10;
                    return damage;
                case 4:
                    damage += 10;
                    return damage;
                case 5:
                    damage += 15;
                    return damage;
            }
            return damage;
        }
        public virtual void Attack(Unit unit)
        {
            unit.SetHealth(unit.GetHealth() - this.damage);
            Print(unit);
        }
        public virtual void Print(Unit unit)
        {
            Console.WriteLine($"{this.GetName()} attack {unit.GetName()} for " +
                $"{IncreasedAtttack(this.GetLvl())}. {unit.GetName()} HP - {unit.GetHealth()}");
        }
    }
}
