using InterfacesWar_Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesWar_Core.Weapons
{
    internal class Sword : IMelee
    {
        int damage = 20;
        string name = "unsigned";

        public Sword(string newName)
        {
            name = newName;
        }

        public void MeleeAttack()
        {
            Console.WriteLine($"Sword attack! Damage given: {damage}");
        }

        public void Upgrade()
        {
            damage += 20;
            Console.WriteLine($"Sword was upgraded by 20 DP");
        }
    }
}
