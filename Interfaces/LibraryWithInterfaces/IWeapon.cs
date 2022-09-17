﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWithInterfaces
{
    public interface IWeapon : IUpgradeble, IRepairible, IReload
    {
        int Damage { get; set; }

        void Shoot();
    }
}