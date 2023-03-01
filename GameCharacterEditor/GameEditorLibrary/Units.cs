﻿using System;
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
                case "Warrior":
                    Warrior warrior = new Warrior();
                    UnitList.Add(warrior);
                    return warrior;
                case "Rogue":
                    Unit rogue = new Rogue();
                    UnitList.Add(rogue);
                    return rogue;
                case "Wizard":
                    Wizard wizard = new Wizard();
                    UnitList.Add(wizard);
                    return wizard;
                default:
                    return null;
            }
        }

        public static void Clear()
        {
            UnitList.Clear();
        }
    }
}