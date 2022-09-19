using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWithInterface
{
    public class Sword : IMeleeWeapons
    {
        public int MeleeDamage { get; set; }
        public int Condition { get; set; }

        public int upgrade = 10;
        public int repair = 10;

        public Sword (int meleeDamage, int condition)
        {
            MeleeDamage = meleeDamage;
            Condition = condition;
        }   

        public void MeleeHit()
        {
            Condition--;
            Console.WriteLine($"Sword hit with {MeleeDamage} damage. " +
                $"Condition: {Condition}");
        }

        public void Upgrade()
        {
            MeleeDamage += upgrade;
            Console.WriteLine($"Sword is upgraded by {upgrade}. Damage: {MeleeDamage}");
        }

        public void Repair()
        {
            Condition += repair;
            Console.WriteLine($"Sword is repaired by {repair}. Condition: {Condition}");
        }
    }
}
