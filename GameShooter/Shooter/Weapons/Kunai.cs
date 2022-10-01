using InterfacesWar_Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesWar_Core.Weapons
{
    internal class Kunai : IThrowable
    {
        int damage = 17;
        string name = "unsigned";
        public Kunai(string newName)
        {
            name = newName;
        }
        public void Throw()
        {
            Console.WriteLine($"Kunai has been throwed! Damage given: {damage}");
        }

        public void Upgrade()
        {
            damage += 2;
            Console.WriteLine("Kunai was upgraded by 2 DP");
        }
    }
}
