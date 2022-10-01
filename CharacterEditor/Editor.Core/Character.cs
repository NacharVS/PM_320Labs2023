using Editor.Core.Enums;
using Editor.Core.Helpers;
using Editor.Core.Abilities;
using Editor.Core.Inventory;

namespace Editor.Core
{
    public abstract class Character
    {
        public BaseStatBoundary StatsBoundary;
        public string? Name { get; set; }
        public List<InventoryItem> Inventory { get; set; }
        public double HealthPoints { get; set; }
        public double ManaPoints { get; set; }
        public double PhysicalDamage { get; set; }
        public double MagicDamage { get; set; }
        public double PhysicalDefense { get; set; }
        public double MagicDefense { get; set; }
        
        public IEnumerable<Ability?>? Abilities { get; internal set; }

        private int _strength;
        private int _dexterity;
        private int _constitution;
        private int _intelligence;
        private int _experience;
        private int _level = 1;
        public int InventoryCapacity { get; set; }

        public Character (BaseStatBoundary statsBoundary, int availableSkillPoints, 
            int experience, IEnumerable<Ability?>? abilities, string? name, List<InventoryItem> inventory)
        {
            StatsBoundary = statsBoundary;
            AvailableSkillPoints = availableSkillPoints;
            _experience = experience;
            Abilities = abilities;
            Name = name;
            Inventory = inventory;
            InventoryCapacity = 15;

            CalculateLevel(this, new ExpChangeArgs(experience));

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
            OnExperienceChange += CalculateLevel;
            OnLevelChange += (_, args) =>
            {
                _level = args.Level;
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
        private void CalculateLevel(Character sender, ExpChangeArgs args)
        {
            var exp = 0;
            var level = 1;

            while (true)
            {
                exp += level * 1000;
                if (args.Amount < exp)
                {
                    break;
                }
                ++level;
            }

            Level = level;
            _experience = args.Amount;
        }

        public void AddItemToInventory(InventoryItem item)
        {
            if (Inventory.Count >= InventoryCapacity)
            {
                throw new Exception("Max capacity");
            }
            Inventory.Add(item);
        }

        public void RemoveItemFromInventory(string name)
        {
            Inventory.Remove(Inventory.FirstOrDefault(x => x.Name == name));
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