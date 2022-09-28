using WeaponGame_Core.Characters;
using WeaponGame_Core.Weapons;
using WeaponGame;
namespace WeaponGameConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleLogger cons = new ConsoleLogger();
            Warrior warrior1 = new Warrior();
            Warrior warrior2 = new Warrior();
            Engineer enginer = new Engineer();
            Ak47 ak = new Ak47();
            ak.Repair();
        }
    }
}
