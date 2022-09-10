using Editor.Core.Enums;

namespace Editor.Core
{
    public abstract class Character
    {
        public BaseStatBoundary StatsBoundary;
        public double HealthPoints { get; private protected set; }
        public double ManaPoints { get; private protected set; }
        
        public double PhysicalDamage { get; private protected set; }
        public double MagicDamage { get; private protected set; }
        public double PhysicalDefense { get; private protected set; }
        public double MagicDefense { get; private protected set; }

        private int _strength;
        private int _dexterity;
        private int _constitution;
        private int _intelligence;

        public Character (BaseStatBoundary statsBoundary, int availableSkillPoints)
        {
            StatsBoundary = statsBoundary;
            AvailableSkillPoints = availableSkillPoints;
        }

        public int Strength
        {
            get
            {
                return _strength;
            }
            set
            {
                if (value <= StatsBoundary.MaxStrength && value >= StatsBoundary.MinStrength)
                {
                    OnStrengthChange?.Invoke(this, value - _strength);
                    _strength = value;
                }
            }
        }
        public int Dexterity
        {
            get
            {
                return _dexterity;
            }
            set
            {
                if (value <= StatsBoundary.MaxDexterity && value >= StatsBoundary.MinDexterity)
                {
                    _dexterity = value;
                    OnDexterityChange?.Invoke(this, value - _dexterity);
                }
            }
        }
        public int Constitution
        {
            get
            {
                return _constitution;
            }
            set
            {
                if (value <= StatsBoundary.MaxConstitution && value >= StatsBoundary.MinConstitution)
                {
                    _constitution = value;
                    OnConstitutionChange?.Invoke(this, value - _constitution);
                }
            }
        }
        public int Intelligence
        {
            get
            {
                return _intelligence;
            }
            set
            {
                if (value <= StatsBoundary.MaxIntelligence && value >= StatsBoundary.MinIntelligence)
                {
                    _intelligence = value;
                    OnIntelligenceChange?.Invoke(this, value - _intelligence);
                }
            }
        }
        public int AvailableSkillPoints { get; set; }

        public delegate void HandleStatChange(Character sender, int difference);

        public event HandleStatChange? OnStrengthChange;
        public event HandleStatChange? OnDexterityChange;
        public event HandleStatChange? OnConstitutionChange;
        public event HandleStatChange? OnIntelligenceChange;
    }
}