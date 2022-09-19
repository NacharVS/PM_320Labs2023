using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWithInterface
{
    public interface IFirearms : IUpgrade, IRepairible, IReloadable
    {
        public int GunshotDamage { get; set; }

        public void SingleShot();
    }
}
