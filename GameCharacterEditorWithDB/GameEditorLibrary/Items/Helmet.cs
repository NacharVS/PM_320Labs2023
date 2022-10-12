using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEditorLibrary
{
    public class Helmet
    {
        public string Material;

        public Helmet(string material)
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
                            unit.Intelligence += 1;
                            unit.phDefention += 1;
                            unit.HP += 1;
                            unit.MP += 1;
                            unit.attackDamage += 1;
                            break;
                        case "Chainmail":
                            unit.Intelligence += 2;
                            unit.phDefention += 2;
                            unit.HP += 2;
                            unit.MP += 2;
                            unit.attackDamage += 2;
                            break;
                        case "Iron":
                            unit.Intelligence += 3;
                            unit.phDefention += 3;
                            unit.HP += 3;
                            unit.MP += 3;
                            unit.attackDamage += 3;
                            break;
                    }
                }
                else
                {
                    switch (material)
                    {
                        case "Leather":
                            unit.Intelligence -= 1;
                            unit.phDefention -= 1;
                            unit.HP -= 1;
                            unit.MP -= 1;
                            unit.attackDamage -= 1;
                            break;
                        case "Chainmail":
                            unit.Intelligence -= 2;
                            unit.phDefention -= 2;
                            unit.HP -= 2;
                            unit.MP -= 2;
                            unit.attackDamage -= 2;
                            break;
                        case "Iron":
                            unit.Intelligence -= 3;
                            unit.phDefention -= 3;
                            unit.HP -= 3;
                            unit.MP -= 3;
                            unit.attackDamage -= 3;
                            break;
                    }
                }
            }
            catch (Exception ex) { }
        }
    }
}
