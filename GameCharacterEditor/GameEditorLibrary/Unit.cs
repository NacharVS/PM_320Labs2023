using System;

namespace GameEditorLibrary
{
    public class Unit
    {
        public delegate void StrengthChangedDelegate();
        public delegate void DexterityChangedDelegate();
        public delegate void ConstitutionChangedDelegate();
        public delegate void IntelligenceChangedDelegate();
        public int minStrength { get; set; }
        public int maxStrength;
        private int _strength;
        public int strength
        {
            get { return _strength; }
            set
            {
                _strength = value;
                StrengthChangedEvent?.Invoke();
            }
        }
        public int minDexterity;
        public int maxDexterity;
        private int _dexterity;
        public int dexterity
        {
            get { return _dexterity; }
            set
            {
                _dexterity = value;
                DexterityChangedEvent?.Invoke();
            }
        }
        public int minConstitution;
        public int maxConstitution;
        private int _constitution;
        public int constitution
        {
            get { return _constitution; }
            set
            {
                _constitution = value;
                ConstitutionChangedEvent?.Invoke();
            }
        }
        public int minIntelligence;
        public int maxIintelligence;
        private int _intelligence;
        public int intelligence
        {
            get { return _intelligence; }
            set
            {
                _intelligence = value;
                IntelligenceChangedEvent?.Invoke();
            }
        }
        public int attackDamage;
        public int manaAttack;
        public double phDefention;
        public double HP;
        public double MP;

        public Unit() { }

        public event StrengthChangedDelegate StrengthChangedEvent;
        public event DexterityChangedDelegate DexterityChangedEvent;
        public event ConstitutionChangedDelegate ConstitutionChangedEvent;
        public event IntelligenceChangedDelegate IntelligenceChangedEvent;


    }
}