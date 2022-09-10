using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEditorLibrary
{
    public class Units
    {
        public static List<Unit> UnitList = new List<Unit>();

        public static Unit Info(string name)
        {
            switch (name)
            {
                case "Warrier":
                    Warrier warrier = new Warrier();
                    return warrier;
                case "Rogue":
                    Unit rogue = new Rogue();
                    return rogue;
                case "Wizard":
                    Wizard wizard = new Wizard();
                    return wizard;
                default:
                    return null;
            }
        }
    }
}
