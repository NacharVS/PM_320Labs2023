using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWarcraft
{
    public class GameLogic
    {
        int count = 1;
        public Unit unit1;
        public Unit unit2;

        public Unit mage1;

        public GameLogic(Unit unit1, Unit unit2)
        {
            this.unit1 = unit1;
            this.unit2 = unit2;
        }

        public void run()
        {
            Console.WriteLine(unit1.name + " and " + unit2.name);




            while (true)
            {
                if (count % 2 == 0)
                {
                    switch (unit1)
                    {
                        case Mage mage:
                            mage.attack(unit2);
                            mage.blizzard(unit2);
                            break;
                        case Footman footman:
                            footman.attack(unit2);
                            break;
                        case Dragon dragon:
                            dragon.attack(unit2);
                            dragon.fireBreath(unit2);
                            break;
                        case GuardTower tower:
                            tower.attack(unit2);
                            break;
                        case Archer archer:
                            archer.attack(unit2);
                            break;
                    }


                    if (unit2.isDestroyed())
                    {
                        Console.WriteLine(unit2.name + " is destroy!");
                        break;
                    }
                    showAttack(unit1);
                    showHealth(unit2);
                }
                else
                {
                    switch (unit2)
                    {
                        case Mage mage:
                            mage.attack(unit1);
                            mage.blizzard(unit1);
                            break;
                        case Footman footman:
                            footman.attack(unit1);
                            break;
                        case Dragon dragon:
                            dragon.attack(unit1);
                            dragon.fireBreath(unit1);
                            break;
                        case GuardTower tower:
                            tower.attack(unit1);
                            break;
                        case Archer archer:
                            archer.attack(unit1);
                            break;
                    }

                    showAttack(unit2);
                    showHealth(unit1);

                    if (unit1.isDestroyed())
                    {
                        Console.WriteLine(unit1.name + " is destroy!");
                        break;
                    }
                }
                count++;
                System.Threading.Thread.Sleep(1000);
            }

        }

        public static void showAttack(Unit unit)
        {
            if (unit is Range mage)
            {
                Console.WriteLine(mage.name + ": attack " + mage.damage + " | mana: " + mage.mana);
            }
            else if (unit is Military military)
            {
                Console.WriteLine(military.name + ": damage " + military.damage + "armor: " + military.armor);
            }
            else if (unit is GuardTower tower)
            {
                Console.WriteLine(tower.name + ": attack " + tower.damage + " | range" + tower.range);
            }

        }



        public static void showHealth(Unit unit)
        {
            Console.WriteLine(unit.name + ":  health:" + unit.health);
            Console.WriteLine();
        }
    }

}
