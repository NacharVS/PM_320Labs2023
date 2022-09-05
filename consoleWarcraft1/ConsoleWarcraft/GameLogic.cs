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
            Console.WriteLine(unit1.name + " and " + unit2.name );
            
            
            
            
            while (true)
            {
                if (count % 2 == 0)
                {
                    if (unit1 is Mage mage)
                    {
                        mage.attack(unit2);
                        mage.blizzard(unit2);
                        showMageAttack(mage);
                        showHealth(unit2);
                    }

                    if(unit1 is Footman footman)
                    {
                        footman.attack(unit2);
                    }

                    if (unit2.isDestroyed())
                    {
                        Console.WriteLine(unit2.name + " is destroy!");
                        break;
                    }
                }
                else
                {
                    if (unit2 is Mage mage)
                    {
                        mage.attack(unit1);
                        mage.blizzard(unit1);
                        showMageAttack(mage);
                        showHealth(unit1);
                    }
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
        
        public void startGame(Unit unit1 , Unit unit2) {
            
        }

        public static void showMageAttack(Mage mage)
        {
            Console.WriteLine(mage.name + ": attack "+ mage.damage + " | mana: " + mage.mana);
        }
        
        public static void showFootmanAttack(Footman footman)
        {
            Console.WriteLine(footman.name + ": attack "+ footman.damage);
        }
        
        public static void showHealth(Unit unit)
        {
            Console.WriteLine(unit.name + ":  health:" + unit.health);
            Console.WriteLine();
        }
    }
    
}
