using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWithInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            Shooter shooter = new Shooter();
            Mechanic mechanic = new Mechanic();

            Pistol pistol = new Pistol();
            Machinegun machinegun = new Machinegun();
            Sword sword = new Sword();
            Shuriken shuriken = new Shuriken();
            Knife knife = new Knife();

            shooter.SingleShot(pistol);
            shooter.AutoShot(machinegun);
            shooter.MeleeHit(sword);
            shooter.ThrowHit(shuriken);
            shooter.MeleeHit(knife);
            shooter.ThrowHit(knife);

            /*mechanic.Upgrade(pistol);
            mechanic.Repair(pistol);
            mechanic.Upgrade(machinegun);
            mechanic.Repair(machinegun);
            mechanic.Upgrade(sword);
            mechanic.Repair(sword);
            mechanic.Upgrade(shuriken);
            mechanic.Repair(shuriken);
            mechanic.Upgrade(knife);
            mechanic.Repair(knife);*/
        }
    }
}
