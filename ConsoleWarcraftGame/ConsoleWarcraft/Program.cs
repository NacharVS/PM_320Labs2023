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

            units[0].Notify += DisplayMessage;
            units[1].Notify += DisplayMessage;

            while ((units[0].IsDestroyed == false) && (units[1].IsDestroyed == false))
            {
                string[] attack = (units[0].Attack()).Split(".");
                units[1].Health = units[1].Health - Convert.ToInt32(attack[1]);
                Console.WriteLine(attack[0]);
                units[1].Checking();
                Thread.Sleep(500);

                if (units[1].IsDestroyed == true)
                {
                    return;
                }

                string[] attackTwo = (units[1].Attack()).Split(".");
                units[0].Health = units[0].Health - Convert.ToInt32(attackTwo[1]);
                Console.WriteLine(attackTwo[0]);
                units[0].Checking();
                Thread.Sleep(500);
            }
            Console.WriteLine("The End");
        }

        public static void DisplayMessage(string message) => Console.WriteLine(message);
    }
}
