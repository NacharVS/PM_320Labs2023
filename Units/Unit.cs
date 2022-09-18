using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units
{
    class Unit
    {
        protected int strength;
        protected int dexterity;
        protected int intelligence;
        protected int constitution;

        public int Strength
        {
            get { return strength; }
            set
            {
                if (value >= minStrength && value <= maxStrength)
                {
                    strength = value;

                    StrengthChangedEvent?.Invoke();
                }
            }
        }
        public int Dexterity
        {
            get { return dexterity; }
            set
            {
                if (value >= minDexterity && value <= maxDexterity)
                {
                    dexterity = value;

                    DexterityChangedEvent?.Invoke();
                }
            }
        }
        public int Constitution
        {
            get { return constitution; }
            set
            {
                if (value >= minConstitution && value <= maxConstitution)
                {
                    constitution = value;

                    ConstitutionChangedEvent?.Invoke();
                }
            }
        }
        public int Intelligence
        {
            get { return intelligence; }
            set
            {
                if (value >= minIntelligence && value <= maxIntelligence)
                {
                    intelligence = value;

                    IntelligenceChangedEvent?.Invoke();
                }
            }
        }

        public double healthPoint;
        public double damage;
        public double defense;
        public double manaPoint;
        public int minStrength;
        public int maxStrength;
        public int minDexterity;
        public int maxDexterity;
        public int minConstitution;
        public int maxConstitution;
        public int minIntelligence;
        public int maxIntelligence;

        public delegate void ParameterChangedDelegate();
        public event ParameterChangedDelegate StrengthChangedEvent;
        public event ParameterChangedDelegate DexterityChangedEvent;
        public event ParameterChangedDelegate ConstitutionChangedEvent;
        public event ParameterChangedDelegate IntelligenceChangedEvent;
    }
}
