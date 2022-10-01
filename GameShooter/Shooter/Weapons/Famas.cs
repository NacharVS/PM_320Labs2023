using InterfacesWar_Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesWar_Core.Weapons
{
    internal class Famas : IAutomaticShoot, ISingleShoot
    {
        int damage = 20;
        string name = "unsigned";
        public Famas(string newName)
        {
            name = newName;
        }

        public void AutoShoot()
        {
            Console.WriteLine("Famas made a lot of shoots!");
        }

        public void SingleShoot()
        {
            Console.WriteLine($"Famas made a single shoot! Damage given: {damage}");
        }

        public void Upgrade()
        {
            damage += 10;
            Console.WriteLine("Famas damage was upgraded up by 10 DP!");
        }
    }
}
