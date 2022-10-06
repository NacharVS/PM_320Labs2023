using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEditorLibrary
{
    public class Helmet : IChangeStat
    {
        public string Material;

        public Helmet(string material)
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
                        unit.phDefention += 20;
                        unit.HP += 3;
                        unit.attackDamage += 6;
                        break;
                    case "Chainmail":
                        unit.phDefention += 40;
                        unit.HP += 5;
                        unit.attackDamage += 8;
                        break;
                    case "Iron":
                        unit.phDefention += 60;
                        unit.HP += 8;
                        unit.attackDamage += 10;
                        break;
                }
            }
            else
            {
                switch (material)
                {
                    case "Leather":
                        unit.phDefention -= 20;
                        unit.HP -= 3;
                        unit.attackDamage -= 6;
                        break;
                    case "Chainmail":
                        unit.phDefention -= 40;
                        unit.HP -= 5;
                        unit.attackDamage -= 8;
                        break;
                    case "Iron":
                        unit.phDefention -= 60;
                        unit.HP -= 8;
                        unit.attackDamage -= 10;
                        break;
                }
            }
        }
    }
}
