using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warcraft3
{
    internal class Range:Military
    {
        public int range;
        public int mana;
        
        public Range(int range, int mana)
        {
            this.range = range;
            this.mana = mana;
        }
        public Range()
        {

        }
    }
}
