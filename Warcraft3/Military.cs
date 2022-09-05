using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warcraft3
{
    internal class Military:Moveble
    {
        int damage;
        int attackSpeed;
        int armor;

        public Military(string name, int health, int cost, int lvl, int maxHP, int speed,
            int damage, int attackSpeed, int armor) : base(name, health, cost, lvl, maxHP, speed)
        {
            this.damage = damage;   
            this.attackSpeed = attackSpeed;
            this.armor = armor;
        }
        public Military()
        {
            
        }

        public Military(string name, int health, int cost, int lvl, int maxHP, int speed) : base(name, health, cost, lvl, maxHP, speed)
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


        public virtual void Attack(Military military)
        {
            military.SetHealth(military.GetHealth() - this.damage);
            Print(military);
        }
        public virtual void Print(Military military)
        {
            Console.WriteLine($"{this.GetName()} attack {military.GetName()} for " +
                $"{IncreasedAtttack(this.GetLvl())}. {military.GetName()} HP - {military.GetHealth()}");
        }

        public int GetDamage()
        {
            return damage;
        }
        public void SetAttackSpeed(int attack)
        {
            attackSpeed = attack;
        }
        public int GetAttackSpeed()
        {
            return attackSpeed;
        }

    }
}
