using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWithInterfaces
{
    public interface IReload
    {
        int MaxShots { get; set; }
        int CurrentShots { get; set; }

        void Reload();
    }
}
