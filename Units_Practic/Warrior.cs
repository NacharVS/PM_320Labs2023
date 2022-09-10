using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units_Practic
{
    public class Warrior : Unit
    {
        public Warrior()
        {
            characteristics = new Characteristics(Units.Warrior);
        }
    }
}
