using System;
using System.Collections.Generic;

namespace ConsoleWarcraft
{
    class Program
    {
        static void Main()
        {
            int count = 1;

            int player1 = 0;
            int player2 = 0;

            Mage mage1 = new Mage("Voland", 1000, 750, 100, 100, 100, 100, 200, 200, false);
            Mage mage2 = new Mage("Potter", 1000, 50, 15, 100, 100, 100, 200, 200, false);
            Footman footman1 = new Footman("Worgen", 2500, 45000, 1000, 90, 30, 300,  false);
            Archer archer1 = new Archer("Archer", 1500, 15000, 1000, 90, 30, 300, 4, false);
            Dragon dragon1 = new Dragon("Sparky", 1000, 50, 15, 100, 100, 100, 200, 200, false);
            GuardTower tower1 = new GuardTower("Tower of ghosts", 10000, 50000, 300, 20, 50, 90, false);

            Blacksmith blacksmith = new Blacksmith("Anvil", 2, 3, 3000, 1000);

            blacksmith.UpgradeEvent += showUpgrade;

            //List<Unit> units = new List<Unit> { };

            //units.Add(mage1);
            //units.Add(mage2);
            //units.Add(footman1);
            //units.Add(archer1);
            //units.Add(dragon1);
            //units.Add(tower1);

            Unit[] units = new Unit[] { mage1, mage2, footman1, dragon1, tower1, archer1 };



            startGame();


             void startGame()
            {
                Console.WriteLine();
                for (int i = 0; i < units.Length; i++)
                {
                    Console.WriteLine($"{i + 1} {units[i].name}  level: {units[i].level}  health {units[i].health}");
                }
                Console.WriteLine();
                Console.Write("Player 1: choose hero: ");
                player1 = int.Parse(Console.ReadLine()) - 1;

                Console.Write("Player 2: choose hero: ");
                player2 = int.Parse(Console.ReadLine()) - 1;

                blacksmith.UpgradeWeapon(units[player1]);
                blacksmith.UpgradeBow(units[player2]);

                GameLogic game = new GameLogic(units[player1], units[player2]);
                game.run();

                Console.ReadKey();
            }

          
        }

        static void showUpgrade()
        {
            Console.WriteLine("Upgrade succses!");
        }


        public static void showMageAttack(Mage mage)
        {
            Console.WriteLine(mage.name + ": attack " + mage.damage + " | mana: " + mage.mana);
        }

        public static void showFootmanAttack(Footman footman)
        {
            Console.WriteLine(footman.name + ": attack " + footman.damage);
        }

        public static void showHealth(Unit unit)
        {
            Console.WriteLine(unit.name + ":  health:" + unit.health);
            Console.WriteLine();
        }
    }

    public class Dragon : Range
    {
        public Dragon(String name, int health, int cost, int level, int mana, int range, double damage, int attackSpeed, int armor, bool isDestroy)
        {
            this.name = name;
            this.health = health;
            this.cost = cost;
            this.level = level;
            this.isDestroy = isDestroy;
            this.mana = mana;
            this.range = range;
            this.damage = damage;
            this.attackSpeed = attackSpeed;
            this.armor = armor;
        }

        public virtual void move()
        {
            speed = speed + level * 0.3;
        }

        public override void attack(Unit unit)
        {
            damage = attackSpeed + level * 0.2;
            damageUnit(unit);
        }

        public void fireBreath(Unit unit)
        {
            if (mana >= 35)
            {
                damage = range + level * 0.9;
                mana -= 35;
                damageUnit(unit);
            }
        }

        private void damageUnit(Unit unit)
        {
            if (unit is Military military)
            {
                military.health = military.health + military.armor - damage;
            }
            else
            {
                unit.health -= damage;
            }
        }
    }
}