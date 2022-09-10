// Turushkin Sergey, 320P, "EditUnit"

using Units_Practic;

namespace Warcraft
{
    internal static class Program
    {
        static void Main()
        {
            var rog = new Rogue();
            Console.WriteLine($"Health: {rog.healthPoint}, mana: {rog.manaPoint}, physical protection: {rog.physicalProtectionPoint}");
            
            var warr = new Warrior();
            Console.WriteLine($"Health: {warr.healthPoint}, mana: {warr.manaPoint}, physical protection: {warr.physicalProtectionPoint}");

            var wiz = new Wizard();
            Console.WriteLine($"Health: {wiz.healthPoint}, mana: {wiz.manaPoint}, physical protection: {wiz.physicalProtectionPoint}");
        }
    }
}