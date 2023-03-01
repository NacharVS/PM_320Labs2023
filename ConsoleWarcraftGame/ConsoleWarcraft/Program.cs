﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarcraftLibrary;

namespace ConsoleWarcraft
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Blacksmith blacksmith = new Blacksmith("Blacksmith");
            List<Unit> units = new List<Unit>();
            Console.WriteLine("Choose first fighter: ");
            string heroOne = Console.ReadLine();
            Console.WriteLine("Choose first fighter's name: ");
            string heroOneName = Console.ReadLine();
            Console.WriteLine("Choose second fighter: ");
            string heroTwo = Console.ReadLine();
            Console.WriteLine("Choose second fighter's name: ");
            string heroTwoName = Console.ReadLine();
            Fab.UnitMaking(units, heroOne, heroOneName, heroTwo, heroTwoName);

            units[0].DestroyingEvent += DisplayMessage;
            units[1].DestroyingEvent += DisplayMessage;
            units[0].HealthChangedEvent += InfoExtended;
            units[1].HealthChangedEvent += InfoExtended;

            Task firstUnitAttack = new Task(() =>
            {
                FirstAttack(units, blacksmith);
            });
            firstUnitAttack.Start();

            Task secondUnitAttack = new Task(() =>
            {
                SecondAttack(units, blacksmith);
            });
            secondUnitAttack.Start();

            secondUnitAttack.Wait();


            Console.WriteLine("The End");
        }
        public static void FirstAttack(List<Unit> units, Blacksmith blacksmith)
        {
            while ((!units[0].IsDestroyed) && (!units[1].IsDestroyed))
            {
                string[] attack = (units[0].Attack(units[1], blacksmith)).Split(".");
                Console.WriteLine(attack[0]);
                units[1].Health = units[1].Health - Convert.ToInt32(attack[1]);
                units[1].Checking();

                Thread.Sleep(500 - units[0].AttackSpeed);
            }
        }

        public static void SecondAttack(List<Unit> units, Blacksmith blacksmith)
        {
            while ((!units[0].IsDestroyed) && (!units[1].IsDestroyed))
            {
                string[] attackTwo = (units[1].Attack(units[0], blacksmith)).Split(".");
                Console.WriteLine(attackTwo[0]);
                units[0].Health = units[0].Health - Convert.ToInt32(attackTwo[1]);
                units[0].Checking();

                Thread.Sleep(500 - units[1].AttackSpeed);
            }
        }

        public static void DisplayMessage(string message) => Console.WriteLine(message);

        public static void InfoExtended(string name, int valueBefore, int value)
        {
            if (valueBefore < value)
            {
                Console.WriteLine($"{name} был захилен, его предыдущий уровень здоровья - {valueBefore}, нынешний - {value}");
            }
            else if (valueBefore > value)
            {
                Console.WriteLine($"{name} был атакован, его предыдущий уровень здоровья - {valueBefore}, нынешний - {value}");
            }
        }
    }
}