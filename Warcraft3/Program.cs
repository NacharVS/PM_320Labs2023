using System;

namespace Warcraft3
{
    class Program
    {
        static void Main(string[] args)
        {
            Military voyaka1 = new Military("Sapsan", 100, 1200,1,100,1,10,6,100);
            /*
            {
                voyaka1.name = "Sapsan";
                voyaka1.SetLvl(1);
                voyaka1.damage = 10;
                voyaka1.health = 100;
                voyaka1.maxHP = 100;
                voyaka1.armor = 5;
                voyaka1.cost = 1200;
                voyaka1.attackSpeed = 1;
            }
            */
            Military voyaka2 = new Military("Bober",80,1300,3,100,1,10,6,100);
            /*
            {
                voyaka2.name = "Bober";
                voyaka1.SetLvl(3);
                voyaka2.damage = 10;
                voyaka2.health = 80;
                voyaka2.maxHP = 100;
                voyaka2.armor = 5;
                voyaka2.cost = 1200;
                voyaka2.attackSpeed = 1;
            }
            */
            GuardTower guard = new GuardTower();
            {

            }
            while (!voyaka1.isDeath() && !voyaka2.isDeath())
            {
                voyaka1.Attack(voyaka2);
                voyaka2.Attack(voyaka1);
            }

        }
    }
}