using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWithInterfaces
{
    public class Shooter
    {
        public Shooter() { }

        public void Hit(IMleeWeapon weapon)
        {
            weapon.Hit();
        }

        public void Throw(IThrowable weapon)
        {
            weapon.Throw();
        }

        public void Attack(IWeapon weapon)
        {
            weapon.Shoot();
        }

        public void MultiAttack(IMultiShoot weapon)
        {
            weapon.MultiShoot();
        }

        public void Reload(IReload weapon)
        {
            weapon.Reload();
        }
    }
}
