﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IThrowable
    {
        int ThrowDamage { get; set; }
        public void Throw();
    }
}
