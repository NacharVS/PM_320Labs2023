using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units_Practic
{
    public class Wizard : Unit
    {
        public Wizard()
        {
            characteristics = new Characteristics(Units.Wizard);
        }
    }
}
