using Editor.Core.Enums;
using Editor.Core.Helpers;
using Editor.Core.Abilities;

namespace Editor.Core
{
    public abstract class Character
    {
        public BaseStatBoundary StatsBoundary;
        public double HealthPoints { get; internal set; }
        public double ManaPoints { get; internal set; }
        public double PhysicalDamage { get; internal set; }
        public double MagicDamage { get; internal set; }
        public double PhysicalDefense { get; internal set; }
        public double MagicDefense { get; internal set; }
        
        public IEnumerable<Ability> Abilities { get; internal set; }

        private int _strength;
        private int _dexterity;
        private int _constitution;
        private int _intelligence;
        private int _experience;
        private int _level;

        public Character (BaseStatBoundary statsBoundary, int availableSkillPoints, int experience)
        {
            StatsBoundary = statsBoundary;
            AvailableSkillPoints = availableSkillPoints;
            Experience = experience;

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
            OnExperienceChange += (_, args) =>
            {
                var exp = _experience;
                while (exp < args.Amount)
                {
                    ++Level;
                    exp += 1000 * Level;
                    if (exp > _experience)
                    {
                        --Level;
                    }
                }
                _experience = args.Amount;
            };
            OnLevelChange += (_, args) =>
            {
                _level = args.Level;
                if (Abilities != null)
                    foreach (var ability in Abilities.Where(x => x.RequiredLevel == args.Level))
                    {
                        ability.Apply(this);
                    }
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

        public int Experience
        {
            get
            {
                return _experience;
            }
            set => OnExperienceChange?.Invoke(this, new ExpChangeArgs(value));
        }

        public int Level
        {
            get
            {
                return _level;
            }
            set => OnLevelChange?.Invoke(this, new LevelChangeArgs(value));
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

                AvailableSkillPoints += args.Difference != 0 ? 1 : 0;
            }
        }

        public delegate void HandleStatChange(Character sender, StatChangeArgs args);
        public delegate void HandleExperienceChange(Character sender, ExpChangeArgs args);

        public delegate void HandleLevelChange(Character sender, LevelChangeArgs args);

        public event HandleStatChange? OnStrengthChange;
        public event HandleStatChange? OnDexterityChange;
        public event HandleStatChange? OnConstitutionChange;
        public event HandleStatChange? OnIntelligenceChange;
        public event HandleExperienceChange? OnExperienceChange;
        public event HandleLevelChange? OnLevelChange;
    }
}