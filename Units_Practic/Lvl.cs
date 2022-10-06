using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
using Units_Practic.Abilities;

namespace Units_Practic
{
    public class Lvl
    {
        private int _lvl = 0;
        public int lvl
        {
            get { return _lvl; }
            set
            {
                _lvl = value;

                if (_lvl % 3 == 0)
                {
                    ++abilitiesPoints;
                }
            }
        }
        public int boostPoints;

        private int _exp = 0;
        public int exp {
            get { return _exp; }
            set
            {
                _exp = value;

                while (_exp >= necessaryExp)
                {
                    ++lvl;
                    boostPoints += 5;
                    _exp = _exp - necessaryExp;
                    necessaryExp += lvl * 1000;
                }
            }
        }
        public int necessaryExp;

        public List<Ability> abilities = new List<Ability>();
        public List<Ability> potentialAbilities;
        public int abilitiesPoints;

        public Lvl()
        {
            lvl = 1;
            boostPoints = 5;
            necessaryExp = 1000;

            potentialAbilities = new List<Ability>
            {
                new AppearanceCat(), new Captivity(), new CloakShadows(),
                new DivineShield(), new Execution(), new Hibernation(),
                new Illusion(), new Jinx(), new Metamorphosis(),
                new PrayerDespair(), new Punishment(), new ShieldRighteous(),
                new Tornado(), new TurtleSpirit(), new WrathPunisher()
            };
        }
    }
}
