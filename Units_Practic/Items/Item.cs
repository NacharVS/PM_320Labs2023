﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units_Practic.Items
{
    public abstract class Item
    {
        public string name;

        public Item(string name)
        {
            this.name = name;
        }

        public Item() { }
    }
}
