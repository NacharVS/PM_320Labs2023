using Editor.Core.Enums;
using Editor.Core.Helpers;
using System.Reflection;

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

        private int _strength { get; set; }
        private int _dexterity;
        private int _constitution;
        private int _intelligence;

        public Character (BaseStatBoundary statsBoundary, int availableSkillPoints)
        {
            StatsBoundary = statsBoundary;
            AvailableSkillPoints = availableSkillPoints;

            OnStrengthChange += CheckSkillPoints;
            OnDexterityChange += CheckSkillPoints;
            OnConstitutionChange += CheckSkillPoints;
            OnIntelligenceChange += CheckSkillPoints;

            OnStrengthChange += (_, args) =>
            {
                if (args.Handled)
                    return;
                _strength += args.Difference;
            };
            OnDexterityChange += (_, args) =>
            {
                if (args.Handled)
                    return;
                _dexterity += args.Difference;
            };
            OnConstitutionChange += (_, args) =>
            {
                if (args.Handled)
                    return;
                _constitution += args.Difference;
            };
            OnIntelligenceChange += (_, args) =>
            {
                if (args.Handled)
                    return;
                _intelligence += args.Difference;
            };
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
                    var difference = value - _strength;

                    OnStrengthChange?.Invoke(this, 
                        new StatChangeArgs(difference,difference > 1 || difference < -1));
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
                    var difference = value - _dexterity;

                    OnDexterityChange?.Invoke(this, 
                        new StatChangeArgs(difference, difference > 1 || difference < -1));
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
                    var difference = value - _constitution;

                    OnConstitutionChange?.Invoke(this, 
                        new StatChangeArgs(difference, difference > 1 || difference < -1));
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
                    var difference = value - _intelligence;

                    OnIntelligenceChange?.Invoke(this,
                        new StatChangeArgs(difference, difference > 1 || difference < -1));
                }
            }
        }
        public int AvailableSkillPoints { get; set; }

        private void CheckSkillPoints(Character sender, StatChangeArgs args)
        {
            if (!args.IgnoreSkillPoints)
            {
                if (args.Difference > 0)
                {
                    if (sender.AvailableSkillPoints <= 0)
                    {
                        args.Handled = true;
                        return;
                    }

                    sender.AvailableSkillPoints -= 1;
                    return;
                }

                AvailableSkillPoints += 1;
            }
        }

        public delegate void HandleStatChange(Character sender, StatChangeArgs args);

        public event HandleStatChange? OnStrengthChange;
        public event HandleStatChange? OnDexterityChange;
        public event HandleStatChange? OnConstitutionChange;
        public event HandleStatChange? OnIntelligenceChange;
    }
}