namespace CharacterEditorCore
{
    public abstract class Item
    {
        private const int _minRang = 1;
        private const int _maxRang = 3;
        public delegate void OnRangChange();
        public event OnRangChange OnRangChangeEvent;

        private int _rang;
        public int Rang
        {
            get { return _rang; }
            set
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
        public string Name { get; protected set; }
        private int _strengthChangeValue;
        public int StrengthChangeValue { get; private set; }
        private int _dexterityChangeValue;
        public int DexterityChangeValue { get; private set; }
        private int _constitutionChangeValue;
        public int ConstitutionChangeValue { get; private set; }
        private int _intellisenceChangeValue;
        public int IntellisenceChangeValue { get; private set; }

        protected Item(int strengthChange, int dexterityChange,
                       int constitutionChange, int intellisenceChange)
        {
            OnRangChangeEvent += UpdateCharacterictics;
            Rang = _minRang;
            _strengthChangeValue = strengthChange;
            _dexterityChangeValue = dexterityChange;
            _constitutionChangeValue = constitutionChange;
            _intellisenceChangeValue = intellisenceChange;
        }

        private void UpdateCharacterictics()
        {
            StrengthChangeValue = _strengthChangeValue * Rang;
            DexterityChangeValue = _dexterityChangeValue * Rang;
            ConstitutionChangeValue = _constitutionChangeValue * Rang;
            IntellisenceChangeValue = _intellisenceChangeValue * Rang;
        }

        public int GetMaxRang()
        {
            return _maxRang;    
        }

        public override string ToString()
        {
            return $"{Name} | {Rang}";
        }
    }
}