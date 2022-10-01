using InterfacesWar_Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesWar_Core.Weapons
{
    internal class SniperRifle : ISingleShoot
    {
        int damage = 60;
        string name = "unsigned";
        public SniperRifle(string newName)
        {
            name = newName;
        }
        public void SingleShoot()
        {
            Console.WriteLine($"Sniper rifle made a shoot! Damage given: {damage}");
        }

        public void Upgrade()
        {
            damage += 10;
            Console.WriteLine("Famas damage was upgraded up by 10 DP!");
        }
    }
}
