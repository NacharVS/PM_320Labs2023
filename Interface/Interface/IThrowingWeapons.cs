using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWithInterface
{
    public interface IThrowingWeapons
    {
        public int ThrowDamage { get; set; }

        public void ThrowHit();
    }
}
