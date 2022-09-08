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
            int tempDamage = this.damage;
            switch (lvl)
            {
                case 2:
                    tempDamage += 5;
                    return tempDamage;
                case 3:
                    tempDamage += 10;
                    return tempDamage;
                case 4:
                    tempDamage += 10;
                    return tempDamage;
                case 5:
                    tempDamage += 15;
                    return tempDamage;
            }
            return tempDamage;
        }
        public virtual void Attack(Unit unit)
        {
            if (unit is Military military)
            {
                unit.SetHealth(military.GetHealth() - IncreasedAtttack(this.GetLvl()) + military.ArmorDamage(military));
                Print(military);
            }
            else
            {
                unit.SetHealth(unit.GetHealth() - IncreasedAtttack(this.GetLvl()));
                Print(unit);
            }

        }
        protected virtual void Print(Unit unit)
        {
            Console.WriteLine($"{this.GetName()} attack {unit.GetName()} for " +
                $"{IncreasedAtttack(this.GetLvl())}. {unit.GetName()} HP - {unit.GetHealth()}");
        }
    }
}
