using InterfacesWar_Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesWar_Core.Weapons
{
    internal class Knife : IMelee, IThrowable
    {
        int damage = 10;
        string name = "unsigned";
        public Knife(string newName)
        {
            name = newName;
        }

        public void MeleeAttack()
        {
            Console.WriteLine($"Knife attack. Damage given: {damage} ");
        }

        public void Throw()
        {
            Console.WriteLine($"Knife has been throwed. Damage given: {damage}");
        }

        public void Upgrade()
        {
            damage += 10;
            Console.WriteLine($"Knife was upgraded by 10 DP");
        }
    }
}
