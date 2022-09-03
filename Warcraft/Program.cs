using System;
using System.Collections.Generic;


namespace Warcraft
{
    
    
    class Program
    {
        
        static void Main(string[] args)
        {
            //bool isDead = false;
            GuardTower tower = new GuardTower(100, 2000, "tower", 1, 20, 11, 1);
            Military military = new Military(100, 3000, "mili", 1, 1, 14, 1, 30);
            Peasant peasant = new Peasant(100, 2500, "Vova", 1, 1, 1, 1, 20);
            Footman footman = new Footman(100, 4000, "man", 1, 1, 17, 1, 35);
            Mage mage = new Mage(110, 5000, "Maggg", 1, 1, 18, 1, 40, 20, 20);
            Dragon dragon = new Dragon(100, 5000, "Dra", 1, 1, 18, 1, 20, 20, 20);

            Unit[] units = new Unit[] { mage, footman};
            var uni = new List<Unit> {military, footman};

            Console.WriteLine(footman.GetHealth());

            while (!footman.GetIsDestroyed() && !mage.GetIsDestroyed())
            {
                footman.Attack(mage);
                
                mage.Attack(footman);
               

                if (units[0].GetHealth() <= 0)
                {
                    units[0].SetIsDestroyed();
                    Console.WriteLine(units[1].GetName() + " is win");
                }

                else if (units[1].GetHealth() <= 0)
                {
                    units[1].SetIsDestroyed();
                    Console.WriteLine(units[0].GetName() + " is win");
                }
            }
        }
    }

    class Unit
    {
        public Random rnd = new Random();
        int health;
        int cost;
        string name;
        int lvl;
        bool isDestroyed = false;

        public Unit(int health, int cost, string name, int lvl)
        {
            this.health = health;
            this.cost = cost;
            this.name = name;
            this.lvl = lvl;
        }

        public bool GetIsDestroyed()
        {
            return isDestroyed;
        }

        public void SetIsDestroyed()
        {
            this.isDestroyed = true;
        }

        public int GetHealth()
        {
            return health;
        }

        public void SetHealth(int health)
        {
            this.health = health;
        }

        public string GetName()
        {
            return name;
        }
    }

    class Moveble : Unit
    {
        int speed;

        public Moveble(int health, int cost, string name, int lvl, int speed)
            : base(health, cost, name, lvl)
        {
            this.speed = speed;
        }



        virtual public void Move()
        {

        }
    }

    class GuardTower : Unit
    {
        int range;
        int dmg;
        int attackSpeed;

        public GuardTower(int health, int cost, string name, int lvl, int range,
            int dmg, int attackSpeed) : base(health, cost, name, lvl)
        {
            this.range = range;
            this.dmg = dmg;
            this.attackSpeed = attackSpeed;
        }

        public string GetName()
        {
            return base.GetName();
        }

        public int GetDmg()
        {
            return dmg;
        }

        public void SetDmg(int dmg)
        {
            this.dmg = dmg;
        }

        public bool GetIsDestroyed()
        {
            return base.GetIsDestroyed();
        }

        public void SetIsDestroyed()
        {
            base.SetIsDestroyed();
        }

        public void Attack(Unit unit)
        {
            unit.SetHealth(unit.GetHealth() - this.GetDmg());
        }
    }

    class Military : Moveble
    {
        int damage;
        int attackSpeed;
        int armor;

        public Military(int health, int cost, string name, int lvl, int speed,
            int damage, int attackSpeed, int armor) : base(health, cost, name, lvl, speed)
        {
            this.damage = damage;
            this.attackSpeed = attackSpeed;
            this.armor = armor;
        }

        public string GetName()
        {
            return base.GetName();
        }

        public int GetDamage()
        {
            return damage;
        }

        public void SetDamage(int damage)
        {
            this.damage = damage;
        }

        public int GetAttackSpeed()
        {
            return damage;
        }

        public void SetAttackSpeed(int attackSpeed)
        {
            this.attackSpeed = attackSpeed;
        }

        public bool GetIsDestroyed()
        {
            return base.GetIsDestroyed();
        }

        public void SetIsDestroyed()
        {
            base.SetIsDestroyed();
        }

        virtual public void Attack(Unit unit)
        {
            unit.SetHealth(unit.GetHealth() - this.GetDamage());
        }
        
    }

    class Peasant : Moveble
    {

        public Peasant(int health, int cost, string name, int lvl, int speed,
                    int damage, int attackSpeed, int armor)
                    : base(health, cost, name, lvl, speed)
        {
            
        }

        public string GetName()
        {
            return base.GetName();
        }

        public void Mining()
        {
            Console.WriteLine("I am mining");
        }

        public void Choping()
        {
            Console.WriteLine("I am choping");
        }
    }

    class Footman : Military
    {

        public Footman(int health, int cost, string name, int lvl, int speed,
                    int damage, int attackSpeed, int armor)
                    : base(health, cost, name, lvl, speed, damage, attackSpeed, armor)
        {

        }

        public string GetName()
        {
            return base.GetName();
        }

        public int GetAttackSpeed()
        {
            return base.GetAttackSpeed();
        }

        public bool GetIsDestroyed()
        {
            return base.GetIsDestroyed();
        }

        public void SetIsDestroyed()
        {
            base.SetIsDestroyed();
        }

        public override void Attack(Unit unit)
        {
            if (this.GetHealth() < 30) 
            {
                Berserker();
            }
            int rand = rnd.Next(1,11);
            if (rand == 1) this.Stun(unit);
            unit.SetHealth(unit.GetHealth() - this.GetDamage());
            Console.WriteLine(this.GetName() + $"({this.GetHealth()})" + " attacked " + unit.GetName() + $"({unit.GetHealth()})");
        }

        public void Berserker()
        {
            SetAttackSpeed(GetAttackSpeed() * 2);
        } //<30% health

        public void Stun(Unit unit) //??
        {
            Console.WriteLine(unit.GetName() + " is stunned");
        }
    }

    class Range : Military
    {
        int range;
        int mana;
    
        public Range(int health, int cost, string name, int lvl, int speed, int damage,
                    int attackSpeed, int armor, int range, int mana)
                    : base(health, cost, name, lvl, speed, damage, attackSpeed, armor)
        {
            this.range = range;
            this.mana = mana;
        }

        public string GetName()
        {
            return base.GetName();
        }

        public override void Attack(Unit unit)
        {

        }
    }

    class Mage : Range
    {
        
        public Mage(int health, int cost, string name, int lvl, int speed,
                    int damage, int attackSpeed, int armor, int range, int mana)
                    : base(health, cost, name, lvl, speed, damage, attackSpeed, armor, range, mana)
        {

        }

        public int GetAttackSpeed()
        {
            return base.GetAttackSpeed();
        }

        public bool GetIsDestroyed()
        {
            return base.GetIsDestroyed();
        }

        public void SetIsDestroyed()
        {
            base.SetIsDestroyed();
        }

        public void Attack(Unit unit)
        {
            if (this.GetHealth() < 50) //< 50%
            {
                this.SetHealth(this.GetHealth() + 10);
            }

            unit.SetHealth(unit.GetHealth() - this.GetDamage());
            Console.WriteLine(this.GetName() + $"({this.GetHealth()})" + " attacked " + unit.GetName() + $"({unit.GetHealth()})");


            int rand = rnd.Next(1, 3);
            if (rand == 1) FireBall(unit);
            else Blizzard(unit);


        }

        public string GetName()
        {
            return base.GetName();
        }

        public void FireBall(Unit unit)
        {
            unit.SetHealth(unit.GetHealth() - 11);
            Console.WriteLine("FireBall!!!");
        }

        public void Blizzard(Unit unit)
        {
            GetAttackSpeed();
            Console.WriteLine("Blizzard!!!");
        } // AttackSpeed down 

        public void Heal()
        {
            this.SetHealth(this.GetHealth() + 12);
        }
    }

    class Dragon : Range
    {

        public Dragon(int health, int cost, string name, int lvl, int speed,
            int damage, int attackSpeed, int armor, int range, int mana)
            : base(health, cost, name, lvl, speed, damage, attackSpeed, armor, range, mana)
        {

        }

        public override void Attack(Unit unit)
        {
            unit.SetHealth(unit.GetHealth() - this.GetDamage());

            int rand = rnd.Next(1, 9);
            if (rand == 1) FireBreath(unit);
            Console.WriteLine(this.GetName() + $"({this.GetHealth()})" + " attacked " + unit.GetName() + $"({unit.GetHealth()})");
        }

        public string GetName()
        {
            return base.GetName();
        }

        public bool GetIsDestroyed()
        {
            return base.GetIsDestroyed();
        }

        public void SetIsDestroyed()
        {
            base.SetIsDestroyed();
        }

        public void FireBreath(Unit unit)
        {
            unit.SetHealth(unit.GetHealth() - 9);
            Console.WriteLine("FireBreath!!!");
        }
    }
}
