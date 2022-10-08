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

        public void ChangeStatistic(Unit unit, string material, bool boo)
        {
            if (boo)
            {
                switch (material)
                {
                    case "Leather":
                        unit.phDefention += 5;
                        unit.HP += 1;
                        break;
                    case "Chainmail":
                        unit.phDefention += 10;
                        unit.HP += 2;
                        break;
                    case "Iron":
                        unit.phDefention += 10;
                        unit.HP += 3;
                        break;
                }
            }
            else
            {
                switch (material)
                {
                    case "Leather":
                        unit.phDefention -= 5;
                        unit.HP -= 1;
                        break;
                    case "Chainmail":
                        unit.phDefention -= 10;
                        unit.HP -= 2;
                        break;
                    case "Iron":
                        unit.phDefention -= 10;
                        unit.HP -= 3;
                        break;
                }
            }
        }
    }
}