using InterfacesWar_Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesWar_Core.Units
{
    internal class Shooter
    {
        int hp = 150;
        IWeapon weapon;
        public Shooter()
        {
        }
        public void TakeWeapon(IWeapon newWeapon)
        {
            weapon = newWeapon;
        }

        public void MeleeAttack(IMelee weapon)
        {
            weapon.MeleeAttack();
        }

        public void SingleShoot(ISingleShoot weapon)
        {
            weapon.SingleShoot();
        }

        public void Throw(IThrowable weapon)
        {
            weapon.Throw();
        }
        
        public void AutoShoot(IAutomaticShoot weapon)
        {
            weapon.AutoShoot();
        }
    }
}
