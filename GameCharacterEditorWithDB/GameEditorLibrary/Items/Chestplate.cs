using System;
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
            if (boo)
            {
                switch (material)
                {
                    case "Leather":
                        unit.Strength += 2;
                        unit.phDefention += 20;
                        unit.HP += 5;
                        break;
                    case "Chainmail":
                        unit.phDefention += 40;
                        unit.HP += 10;
                        break;
                    case "Iron":
                        unit.phDefention += 60;
                        unit.HP += 20;
                        break;
                }
            }
            else
            {
                switch (material)
                {
                    case "Leather":
                        unit.Strength -= 2;
                        unit.phDefention -= 20;
                        unit.HP -= 5;
                        break;
                    case "Chainmail":
                        unit.phDefention -= 40;
                        unit.HP -= 10;
                        break;
                    case "Iron":
                        unit.phDefention -= 60;
                        unit.HP -= 20;
                        break;
                }
            }
        }
    }
}
