using System;
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
            
            while ((units[0].IsDestroyed == false) && (units[1].IsDestroyed == false))
            {
                var vals = new int[] { 0, units[0].Damage, units[0].Damage + 10, units[0].Damage + 30 };
                var val = vals[rnd.Next(vals.Length)];
                string[] attack = (units[0].Attack(val)).Split(".");
                units[1].Health = units[1].Health - Convert.ToInt32(attack[1]);
                Console.WriteLine(attack[0]);
                units[1].Checking();
                if (units[1].IsDestroyed == true)
                {
                    Console.WriteLine($"{units[1].Name} погиб");
                    break;
                }
                Thread.Sleep(500);

                var valsTwo = new int[] { 0, units[1].Damage, units[0].Damage + 10, units[0].Damage + 30 };
                var valTwo = valsTwo[rnd.Next(vals.Length)];
                string[] attackTwo = (units[1].Attack(valTwo)).Split(".");
                units[0].Health = units[0].Health - Convert.ToInt32(attackTwo[1]);
                Console.WriteLine(attackTwo[0]);
                units[0].Checking();
                if (units[0].IsDestroyed == true)
                {
                    Console.WriteLine($"{units[0].Name} погиб");
                    break;
                }
                Thread.Sleep(500);
            }

            Console.WriteLine("The End");
        }
    }
}
