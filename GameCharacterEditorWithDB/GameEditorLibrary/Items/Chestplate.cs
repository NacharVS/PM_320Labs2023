﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEditorLibrary
{
    public class Chestplate
    {
        public string Material;

        public Chestplate(string material)
        {
            Material = material;
        }

        public void ChangeStatistic(Unit unit, string material, bool boo)
        {
            try
            {
                if (boo)
                {
                    switch (material)
                    {
                        case "Leather":
                            unit.Strength += 1;
                            unit.Constitution += 1;
                            unit.phDefention += 1;
                            unit.HP += 1;
                            unit.MP += 1;
                            break;
                        case "Chainmail":
                            unit.Strength += 2;
                            unit.Constitution += 2;
                            unit.phDefention += 2;
                            unit.HP += 2;
                            unit.MP += 2;
                            break;
                        case "Iron":
                            unit.Strength += 3;
                            unit.Constitution += 3;
                            unit.phDefention += 3;
                            unit.HP += 3;
                            unit.MP += 3;
                            break;
                    }
                }
                else
                {
                    switch (material)
                    {
                        case "Leather":
                            unit.Strength -= 1;
                            unit.Constitution -= 1;
                            unit.phDefention -= 1;
                            unit.HP -= 1;
                            unit.MP -= 1;
                            break;
                        case "Chainmail":
                            unit.Strength -= 2;
                            unit.Constitution -= 2;
                            unit.phDefention -= 2;
                            unit.HP -= 2;
                            unit.MP -= 2;
                            break;
                        case "Iron":
                            unit.Strength -= 3;
                            unit.Constitution -= 3;
                            unit.phDefention -= 3;
                            unit.HP -= 3;
                            unit.MP -= 3;
                            break;
                    }
                }
            }
            catch (Exception ex) { }
        }
    }
}
