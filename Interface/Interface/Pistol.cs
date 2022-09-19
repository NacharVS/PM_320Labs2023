using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWithInterface
{
    public class Pistol : IFirearms
    {
        public int GunshotDamage { get; set; }
        public int Condition { get; set; }
        public int BulletsCount { get; set; }
        public int MaxBulletsCount { get; set; }

        public int upgrade = 10;
        public int repair = 10;

        public Pistol (int gunshotDamage, int condition, int maxBulletsCount)
        {
            GunshotDamage = gunshotDamage;
            Condition = condition;
            BulletsCount = maxBulletsCount;
            MaxBulletsCount = maxBulletsCount;
        }

        public void SingleShot()
        {
            BulletsCount--;
            Condition--;
            Console.WriteLine($"Single shot from a pistol with " +
                $"{GunshotDamage} damage. Count of bullets: {BulletsCount}. " +
                $"Condition: {Condition}");
        }

        public void Upgrade()
        {
            GunshotDamage += upgrade;
            Console.WriteLine($"Pistol is upgraded by {upgrade}");
        }

        public void Repair()
        {
            Condition += repair;
            Console.WriteLine($"Pistol is repaired by {repair}. Condition: {Condition}. Damage: {GunshotDamage}");
        }

        public void Reload()
        {
            BulletsCount = MaxBulletsCount;
            Console.WriteLine($"Pistol is reloaded");
        }
    }
}
