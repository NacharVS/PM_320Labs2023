using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWithInterface
{
    public interface IReloadable
    {
        public int BulletsCount { get; set; }
        public int MaxBulletsCount { get; set; }
        public void Reload();
    }
}
