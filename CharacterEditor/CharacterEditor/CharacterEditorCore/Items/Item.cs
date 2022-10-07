namespace CharacterEditorCore
{
    public abstract class Item
    {
        private const int _minRang = 1;
        private const int _maxRang = 3;
        public delegate void OnRangChange();
        public event OnRangChange OnRangChangeEvent;
        public string Name { get; protected set; }
        private int _strengthChangeValue;
        public int StrengthChangeValue 
        {
            get { return _strengthChangeValue; }
            set
            {
                _strengthChangeValue = value * Rang;
            }
        }
        private int _dexterityChangeValue;
        public int DexterityChangeValue
        {
            get { return _dexterityChangeValue; }
            set 
            {
                _dexterityChangeValue = value * Rang;
            }
        }
        private int _constitutionChangeValue;
        public int ConstitutionChangeValue
        {
            get { return _constitutionChangeValue; }
            set
            {
                _constitutionChangeValue = value * Rang;
            }
        }
        private int _intellisenceChangeValue;
        public int IntellisenceChangeValue
        {
            get { return _intellisenceChangeValue; }
            set
            {
                _intellisenceChangeValue = value * Rang;
            }
        }

        private int _rang;
        public int Rang
        {
            get { return _rang; }
            private set
            { 
                if (value <= _minRang)
                {
                    _rang = _minRang;
                }
                else if (value > _maxRang)
                {
                    _rang = _maxRang;
                }
                else
                {
                    _rang = value;
                }
                OnRangChangeEvent?.Invoke();
            }
        }

        protected Item(int strengthChange, int dexterityChange,
                       int constitutionChange, int intellisenceChange)
        {
            OnRangChangeEvent += UpdateCharacterictics;
            Rang = _minRang;
            StrengthChangeValue = strengthChange;
            DexterityChangeValue = dexterityChange;
            ConstitutionChangeValue = constitutionChange;
            IntellisenceChangeValue = intellisenceChange;
        }

        private void UpdateCharacterictics()
        {
            StrengthChangeValue = _strengthChangeValue;
            DexterityChangeValue = _dexterityChangeValue;
            ConstitutionChangeValue = _constitutionChangeValue;
            IntellisenceChangeValue = _intellisenceChangeValue;
        }
    }
}