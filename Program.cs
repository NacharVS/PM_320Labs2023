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

    
    
}
