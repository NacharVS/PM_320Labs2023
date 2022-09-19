using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWithInterface
{
    public class Knife : IMeleeWeapons, IThrowingWeapons
    {
        public int MeleeDamage { get; set; }
        public int ThrowDamage { get; set; }
        public int Condition { get; set; }

        public int upgrade = 10;
        public int repair = 10;

        public Knife (int meleeDamage, int throwDamage, int condition)
        {
            MeleeDamage = meleeDamage;
            ThrowDamage = throwDamage;
            Condition = condition;
        }

        public void MeleeHit()
        {
            Condition--;
            Console.WriteLine($"Stab with {MeleeDamage} damage. Condition: {Condition}");
        }

        public void ThrowHit()
        {
            Condition--;
            Console.WriteLine($"Knife throw with {ThrowDamage} damage. Condition: {Condition}");
        }

        public void Upgrade()
        {
            MeleeDamage += upgrade;
            ThrowDamage += upgrade;
            Console.WriteLine($"Knife is upgraded by {upgrade}. " +
                $"Melee damage: {MeleeDamage}. Throw damage: {ThrowDamage}");
        }

        public void Repair()
        {
            Condition += repair;
            Console.WriteLine($"Knife is repaired by {repair}. Condition: {Condition}");
        }
    }
}
