

namespace Units
{
    public class UnitMaker
    {
        static public Unit Make(string unitCode, double health, double cost, string name, int lvl = 1, double speed = 1)
        {
            Unit unit = null;

            switch (unitCode)
            {
                case "Peasant":
                case "0":
                case "P":
                    unit = new Peasant(health, cost, name, speed);
                    break;

                /*case "Footman":
                case "1":
                case "F":
                    piece = new Footman(health, cost, name, speed);
                    break;

                case "Mage":
                case "2":
                case "M":
                    piece = new Mage(x, y);
                    break;

                case "GuardTower":
                case "3":
                case "G":
                    piece = new GuardTower(x, y);
                    break;

                case "Dragon":
                case "4":
                case "D":
                    piece = new Dragon(x, y);
                    break;*/

                default: throw (new Exception("Unknown unit code."));
            }

            return unit;
        }

        static public Unit Make(int unitCode, double health, double cost, string name, int lvl = 1, double speed = 1)
        {
            return Make(unitCode.ToString(), health, cost, name);
        }
    }
}
