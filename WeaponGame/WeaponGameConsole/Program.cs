using WeaponGame.Characters;
using WeaponGame.Weapons;

namespace WeaponGameConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //characters
            var bob = new Warrior("Bob");
            var george = new Engineer("George");

            //weapons
            var logger = new ConsoleLogger();
            var ak = new Ak74(logger, 15, 30, 10);
            var knife = new Knife(logger, 30, 10, 10);
            var shuriken = new Shuriken(logger, 15);

            //test
            bob.MeleeAttack(knife);
            bob.Attack(ak);
            george.Repair(ak);
            bob.Throw(shuriken);
        }
    }
}