using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWithInterface
{
    public class Machinegun : IFirearms, IAutoShot
    {
        public int GunshotDamage { get; set; }
        public int Condition { get; set; }
        public int BulletsCount { get; set; }
        public int MaxBulletsCount { get; set; }

        public int upgrade = 10;
        public int repair = 10;

        public Machinegun (int gunshotDamage, int condition, int maxBulletsCount)
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
            Console.WriteLine($"Single shot from a machine gun with " +
                $"{GunshotDamage} damage. Count of bullets: {BulletsCount}. " +
                $"Condition: {Condition}");
        }

        public void AutoShot()
        {
            BulletsCount -= MaxBulletsCount;
            Condition--;
            Console.WriteLine($"Several shot from a machine gun with " +
                $"{GunshotDamage * MaxBulletsCount} damage. " +
                $"Count of bullets: {BulletsCount}. Condition: {Condition}");
        }

        public void Upgrade()
        {
            GunshotDamage += upgrade;
            Console.WriteLine($"Machinegun is upgraded by {upgrade}. Damage: {GunshotDamage}");
        }

        public void Repair()
        {
            Condition += repair;
            Console.WriteLine($"Machinegun is repaired by {repair}. Condition: {Condition}");
        }

        public void Reload()
        {
            BulletsCount = MaxBulletsCount;
            Console.WriteLine($"Machinegun is reloaded");
        }
    }
}
