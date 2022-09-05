using System;

namespace WarCraft_3_ConsoleEdition
{
    class Program
    {
        static Dictionary<string, Unit> unitDict = new Dictionary<string, Unit>()
        {
            {"GuardTower", new GuardTower(15, 35 ,20 ,300, 150, "GuardTower", 1) },
            {"Footman", new Footman(15, 8, 10, 5, 100, 30, "Footman", 1) },
            {"Mage", new Mage(20, 100, 10, 6, 10, 5, 80, 45, "Mage", 1) },
            {"Dragon", new Dragon(30, 300, 20, 15, 20, 5, 200, 100, "Dragon", 1) },
            {"Archer", new Archer(100, 25, 10, 10, 5, 6, 70, 25, "Archer", 1) },
            {"Peasant", new Peasant(5, 30, 10, "Peasant", 1) },
            {"BlackSmith", new Blacksmith(4, 150, 50, "Blacksmith", 1) }
        };

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Welcome to this Game!");
                Console.WriteLine("Please, select 2 Units:");

                foreach (Unit value in unitDict.Values)
                {
                    Console.WriteLine(value.name);
                }

                Console.Write("Write name first Unit: ");
                string firstUnit = Console.ReadLine();

                Console.Write("Write name second Unit: ");
                string secondUnit = Console.ReadLine();

                Console.WriteLine();

                Game.StartGame(unitDict[firstUnit], unitDict[secondUnit]);
            }

            catch
            {
                Console.WriteLine("Wrong input!");
            }
        }
    }

    public class Unit
    {
        public int health;
        public int cost;
        public string name;
        public int level;
        public int timeWithoutAttack;

        public Unit(int health, int cost, string name, int level)
        {
            this.health = health;
            this.cost = cost;
            this.name = name;
            this.level = level;
        }
    }

    class Movable : Unit
    {
        public int speed;
        void Move()
        {
        }

        public Movable(int speed, int health, int cost, string name, int level)
            : base(health, cost, name, level)
        {
            this.speed = speed;
        }
    }

    class GuardTower : Unit
    {
        public int range;
        public int damage;
        public int attackSpeed;
        public void Attack(Unit unit)
        {
            try
            {
                unit.health -= (int)(this.damage -
                        this.damage * (double)((Military)unit).armor / 100);
            }

            catch { unit.health -= this.damage; }
        }

        public GuardTower(int range, int damage, int attackSpeed,
            int health, int cost, string name, int level) : base(health, cost, name, level)
        {
            this.range = range;
            this.damage = damage;
            this.attackSpeed = attackSpeed;
        }
    }

    class Military : Movable
    {
        public int damage;
        public int attackSpeed;
        public int armor;
        public void Attack(Unit unit)
        {
            try
            {
                unit.health -= (int)(this.damage -
                        this.damage * (double)((Military)unit).armor / 100);
            }

            catch { unit.health -= this.damage; }
        }

        public Military(int damage, int attackSpeed, int armor,
            int speed, int health, int cost, string name, int level)
            : base(speed, health, cost, name, level)
        {
            this.damage = damage;
            this.attackSpeed = attackSpeed;
            this.armor = armor;
        }
    }

    class Peasant : Movable
    {
        void Mining() { }
        void Chopping() { }

        public Peasant(int speed, int health, int cost, string name, int level)
            : base(speed, health, cost, name, level)
        {
        }
    }

    class Footman : Military
    {
        public bool isBerserk;

        public void Berserker()
        {
            if (!isBerserk)
            {
                damage *= 2;
            }

            isBerserk = true;
        }

        public void Stun(Movable movable)
        {
            movable.timeWithoutAttack += 5;
        }

        public Footman(int damage, int attackSpeed, int armor, int speed, int health,
            int cost, string name, int level) : base(damage, attackSpeed, armor, speed, health, cost, name, level) 
        {}
    }

    class Range : Military
    {
        public int range;
        public int mana;

        public Range(int range, int mana, int damage, int attackSpeed,
            int armor, int speed, int health, int cost, string name, int level)
           : base(damage, attackSpeed, armor, speed, health, cost, name, level)
        {
            this.range = range;
            this.mana = mana;
        }

        protected void ReportingLackOfMana()
        {
            Console.WriteLine("Not enough mana!");
        }
    }

    class Mage : Range
    {
        public void Fireball(Unit unit)
        {
            if (this.mana >= 20)
            {
                unit.health -= this.damage * 2;
            }

            else
            {
                ReportingLackOfMana();
            }
        }

        public void Blizzard(Unit unit)
        {
            if (this.mana >= 15)
            {
                unit.timeWithoutAttack += 7;
                mana -= 15;
            }

            else
            {
                ReportingLackOfMana();
            }
        }

        public int Heal(Unit unit)
        {
            int hp;

            Console.Write("Enter the number of HP: ");
            hp = int.Parse(Console.ReadLine());

            if (hp * 5 <= this.mana)
            {
                unit.health += hp;
                this.mana -= hp * 5;
            }

            else
            {
                ReportingLackOfMana();
            }

            return hp;
        }

        public Mage(int range, int mana, int damage, int attackSpeed, int armor,
            int speed, int health, int cost, string name, int level) : base(range,
                mana, damage, attackSpeed, armor, speed, health, cost, name, level)
        {
        }
    }

    class Dragon : Range
    {
        public void FireBreath(Unit unit)
        {
            if (this.mana >= 35)
            {
                unit.health -= this.damage * 3;
                mana -= 35;
            }

            else
            {
                ReportingLackOfMana();
            }
        }

        public Dragon(int range, int mana, int damage, int attackSpeed,
            int armor, int speed, int health, int cost, string name, int level)
           : base(range, mana, damage, attackSpeed, armor, speed, health, cost, name, level)
        {
        }
    }

    class Archer : Range 
    {
        int arrowCount;

        public Archer(int arrowCount, int range, int damage, int attackSpeed,
            int armor, int speed, int health, int cost, string name, int level)
            : base(arrowCount, range, damage, attackSpeed, armor, speed, health, cost, name, level) 
        {
            this.arrowCount = arrowCount;
        }
    }

    class Blacksmith : Unit
    {
        int buff;

        public Blacksmith (int buff, int health, int cost, string name, int level) : base(health, cost, name, level)
        {
            this.buff = buff;
        }

        public void UpgradeArmor(Dictionary<string, Unit> unitList)
        {
            foreach (var value in unitList)
            {
                value.Value.health += 1000;
                Console.WriteLine(value.Value.health);
            }
        }
    }

}
