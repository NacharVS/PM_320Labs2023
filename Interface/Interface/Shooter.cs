using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWithInterface
{
    public class Shooter
    {
        public void SingleShot(IFirearms weapon)
        {
            weapon.SingleShot();
        }

        public void AutoShot(IAutoShot weapon)
        {
            weapon.AutoShot();
        }

        public void MeleeHit(IMeleeWeapons weapon)
        {
            weapon.MeleeHit();
        }

        public void ThrowHit(IThrowingWeapons weapon)
        {
            weapon.ThrowHit();
        }

        public void Reload (IReloadable weapon)
        {
            weapon.Reload();
        }
    }
}
