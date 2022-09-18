using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warcraft3
{
    internal class Military:Moveble
    {
        public delegate void healthChangedDelegate();
        int damage;
        int attackSpeed;
        double armor;

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

        public Military(string name, int health, int cost, int lvl, int maxHP, int speed) : 
            base(name, health, cost, lvl, maxHP, speed)
        {
            healthChangedEvent += ChangeDamageAfterEvent;
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
            if(unit is Military military)
            {
                unit.SetHealth(military.GetHealth() - IncreasedAtttack(this.GetLvl()) + ArmorDamage(military)); //upgrade armor
                Print(military);
            }
            else
            {
                unit.SetHealth(unit.GetHealth() - IncreasedAtttack(this.GetLvl()));
                Print(unit);
            }
           
        }
        private void ChangeDamageAfterEvent()
        {
            if (!this.GetIsDestroyed())
            {
                damage += 10;
            }
        }

        public override void SetHealth(double newHealth)
        {
            var difference = newHealth - GetHealth();

            if(difference <= -20)
            {
                healthChangedEvent?.Invoke();
            }
            base.SetHealth(newHealth);
        }
        public double ArmorDamage(Military military)
        {
            double savedDmg = IncreasedAtttack(this.GetLvl()) * 0.3;
            military.armor -= savedDmg;
            return savedDmg;
        }
        protected virtual void Print(Unit unit) 
        {
            Console.WriteLine($"{this.GetName()} attack {unit.GetName()} for " +
                $"{IncreasedAtttack(this.GetLvl())}. {unit.GetName()} HP - {unit.GetHealth()}");
        }

        public int GetDamage()
        {
            return damage;
        }
        public void SetAttackSpeed(int attack)
        {
            attackSpeed = attack;
        }
        public void SetArmor(int countOfArmor)
        {
            this.armor += countOfArmor;
            if(this.armor > 100)                               //UPGRADE
            {
                this.armor = 100;
            }
        } 
        public void SetDamage(int damageCount)
        {
            this.damage += damageCount;
        }
        public int GetAttackSpeed()
        {
            return attackSpeed;
        }

        public healthChangedDelegate healthChangedEvent;
    }
}
