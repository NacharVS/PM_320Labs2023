using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEditorLibrary
{
    public class Boots
    {
        public string Material;

        public Boots(string material)
        {
            Material = material;
        }

        public bool ChangeStatistic(Unit unit, string material, bool boo)
        {
            try
            {
                if (boo)
                {
                    switch (material)
                    {
                        case "Leather":
                            if (unit.Level >= 1)
                            {
                                unit.Dexterity += 1;
                                unit.Strength += 1;
                                unit.phDefention += 1;
                                unit.HP += 1;
                                unit.MP += 1;
                            }
                            else
                            {
                                return false;
                            }
                            break;
                        case "Chainmail":
                            if (unit.Level >= 2)
                            {
                                unit.Dexterity += 2;
                                unit.Strength += 2;
                                unit.phDefention += 2;
                                unit.HP += 2;
                                unit.MP += 2;
                            }
                            else
                            {
                                return false;
                            }
                            break;
                        case "Iron":
                            if (unit.Level >= 3)
                            {
                                unit.Dexterity += 3;
                                unit.Strength += 3;
                                unit.phDefention += 3;
                                unit.HP += 3;
                                unit.MP += 3;
                            }
                            else
                            {
                                return false;
                            }
                            break;
                    }
                }
                else
                {
                    switch (material)
                    {
                        case "Leather":
                            if (unit.Level >= 1)
                            {
                                unit.Dexterity -= 1;
                                unit.Strength -= 1;
                                unit.phDefention -= 1;
                                unit.HP -= 1;
                                unit.MP -= 1;
                            }
                            else
                            {
                                return false;
                            }
                            break;
                        case "Chainmail":
                            if (unit.Level >= 2)
                            {
                                unit.Dexterity -= 2;
                                unit.Strength -= 2;
                                unit.phDefention -= 2;
                                unit.HP -= 2;
                                unit.MP -= 2;
                            }
                            else
                            {
                                return false;
                            }
                            break;
                        case "Iron":
                            if (unit.Level >= 3)
                            {
                                unit.Dexterity -= 3;
                                unit.Strength -= 3;
                                unit.phDefention -= 3;
                                unit.HP -= 3;
                                unit.MP -= 3;
                            }
                            else
                            {
                                return false;
                            }
                            break;
                    }
                }
            }
            catch (Exception ex) { }
            return true;
        }
    }
}