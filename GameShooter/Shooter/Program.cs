using InterfacesWar_Core.Interfaces;
using InterfacesWar_Core.Units;
using InterfacesWar_Core.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        Shooter steven = new Shooter();
        Engineer chichanchochi = new Engineer();
        Famas famas = new Famas("famas");
        Knife rejik = new Knife("rejik");
        SniperRifle awp = new SniperRifle("awp");
        Sword mech = new Sword("mech");

        steven.TakeWeapon(rejik);
        steven.TakeWeapon(famas);
        steven.MeleeAttack(rejik);
        steven.SingleShoot(famas);
        chichanchochi.Upgrade(famas);
        steven.SingleShoot(famas);
        steven.AutoShoot(famas);
    }

}
