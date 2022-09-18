using System;
namespace InterfacesGame
{
    public class Gunslinger
    {
        public Gunslinger() 
        {
        }

        public void MultiFire(IHaveAutoMade weapon)
        {
            weapon.AutoModeShoot();
        }

        public void HitByMleeWeapon(IMeleeWeapon weapon)
        {
            weapon.Hit();
        }

        public void ThrowThrowableWeapon(IThrowable weapon)
        {
            weapon.Throw();
        }

        public void Reload(IReloadeble weapon)
        {
            weapon.Reload();
        }

        public void HitByPistol(IHaveSingleMode weapon)
        {
            weapon.SingleShoot();
        }
    }
}
