using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarcraftLibrary
{
    public class Fab
    {
        public static void UnitMaking(List<Unit> units, string heroOne, string heroOneName, string heroTwo, string heroTwoName)
        {
            switch (heroOne)
            {
                case "Dragon":
                    units.Add(new Dragon(heroOneName));
                    break;
                case "Footman":
                    units.Add(new Footman(heroOneName));
                    break;
                case "GuardTower":
                    units.Add(new GuardTower(heroOneName));
                    break;
                case "Mage":
                    units.Add(new Mage(heroOneName));
                    break;
                case "Peasent":
                    units.Add(new Peasent(heroOneName));
                    break;
                case "Archer":
                    units.Add(new Archer(heroOneName));
                    break;
                case "Blacksmith":
                    units.Add(new Blacksmith(heroOneName));
                    break;
                default:
                    Console.WriteLine("Something wrong");
                    break;
            }
            switch (heroTwo)
            {
                case "Dragon":
                    units.Add(new Dragon(heroTwoName));
                    break;
                case "Footman":
                    units.Add(new Footman(heroTwoName));
                    break;
                case "GuardTower":
                    units.Add(new GuardTower(heroTwoName));
                    break;
                case "Mage":
                    units.Add(new Mage(heroTwoName));
                    break;
                case "Peasent":
                    units.Add(new Peasent(heroTwoName));
                    break;
                case "Archer":
                    units.Add(new Archer(heroTwoName));
                    break;
                case "Blacksmith":
                    units.Add(new Blacksmith(heroTwoName));
                    break;
                default:
                    Console.WriteLine("Something wrong");
                    break;
            }
        }
    }
}
