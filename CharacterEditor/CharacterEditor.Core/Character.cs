namespace CharacterEditor.Core
{
    public abstract class Character
    {   
        protected int _strength;
        protected int _dexterity;
        protected int _intelligence;
        protected int _constitution;

        public int Strength 
        {
            get { return _strength; }
            set
            {
                if (value >= minStrength && value <= maxStrength)
                {
                    _strength = value;

                    StrengthChangedEvent?.Invoke();
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
        public int Dexterity 
        {
            get { return _dexterity; }
            set
            {
                if (value >= minDexterity && value <= maxDexterity)
                {
                    _dexterity = value;

                    DexterityChangedEvent?.Invoke();
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            } 
        }
        public int Constitution
        {
            get { return _constitution; }
            set 
            { 
                if (value >= minConstitution && value <= maxConstitution)
                {
                    _constitution = value; 
                
                    ConstitutionChangedEvent?.Invoke();
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
        public int Intelligence 
        {
            get { return _intelligence; }
            set
            {
                if (value >= minIntelligence && value <= maxIntelligence)
                {
                    _intelligence = value;

                    IntelligenceChangedEvent?.Invoke();
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        public double healthPoint;
        public double physicalDamage;
        public double mageDamage;
        public double physicalDefense;
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