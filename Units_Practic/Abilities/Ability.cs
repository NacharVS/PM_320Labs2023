using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units_Practic.Abilities
{
    public abstract class Ability
    {
        public string name;

        public override string ToString()
        {
            return name;
        }
    }
}
