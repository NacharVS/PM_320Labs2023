using System;

namespace InterfacesGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var knife = new Knife(50);
            var shuriken = new Shuriken();
            var sword = new Sword(70);
            var pistol = new Pistol(100);
            var machinegun = new MachineGun(120);
            var Lena = new Gunslinger();
            var Dinar = new Mechanic();


            Lena.MultiFire(machinegun);
            Lena.ThrowThrowableWeapon(knife);
            Lena.ThrowThrowableWeapon(shuriken);
            Lena.HitByPistol(pistol);
            Lena.HitByMleeWeapon(sword);
            Lena.Reload(pistol);

            Dinar.UpgradeWeapon(sword);
            Lena.HitByMleeWeapon(sword);
            Dinar.UpgradeWeapon(pistol);
            Lena.HitByPistol(pistol);
            Dinar.ShowInfo(pistol);
            Dinar.RepairWeapon(pistol);
            Dinar.ShowInfo(pistol);

        }
    }
}
