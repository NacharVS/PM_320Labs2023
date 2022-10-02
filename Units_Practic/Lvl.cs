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

        private int _exp = 0;
        public int exp {
            get { return _exp; }
            set
            {
                _exp = value;

                if (_exp >= necessaryExp)
                {
                    ++lvl;
                    boostPoints += 5;
                    _exp = _exp - necessaryExp;
                    necessaryExp += lvl * 1000;
                }
            }
        }
        public int necessaryExp;

        public Lvl()
        {
            lvl = 1;
            boostPoints = 5;
            necessaryExp = 1000;
        }
    }
}
