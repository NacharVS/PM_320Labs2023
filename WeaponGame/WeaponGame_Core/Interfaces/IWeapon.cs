﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponGame_Core.Interfaces
{
    public interface IWeapon: ILogger,IRepairable,IUpgradable,IReloadable
    {
        
    }
}
