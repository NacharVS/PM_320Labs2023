using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace Units_Practic
{
    public class Lvl
    {
        public int lvl;
        public int boostPoints;

        private int _exp;
        public int exp {
            get { return _exp; }
            set
            {
                if (value + _exp >= necessaryExp)
                {
                    ++lvl;
                    boostPoints += 5;
                    _exp = necessaryExp - value + _exp;
                    necessaryExp += lvl * 1000;
                }
                else if (value + _exp < necessaryExp)
                {
                    _exp += value;
                }
            }
        }
        public int necessaryExp;

        public Lvl()
        {
            lvl = 1;
            boostPoints = 5;
            necessaryExp = 1000;
            exp = 0;
        }
    }
}
