namespace CharacterEditorCore
{
    public abstract class Character
    {
        private const int _levelUpValue = 1000;
        private int _currentLevelExperienceValue = 0;
        private delegate void _charactericticChangedDelegate();
        private _charactericticChangedDelegate _charactericticChangedEvent;
        private delegate void OnLevelUp();
        private  OnLevelUp OnLevelUpEvent;
        private List<Ability> _abilities;
        public List<Ability> Abilities
        {
            get { return _abilities; }
            set
            {
                foreach (var ability in value)
                {
                    _abilities.Add(ability);
                    FillAbilityData(ability);
                }
            }
        }

        private int _availableAbilityCount = 0;
        public int AvailableAbilityCount
        {
            get { return _availableAbilityCount;}
            private set
            {
                if (value < 0)
                {
                    _availableAbilityCount = 0;
                }
                _availableAbilityCount = value;
            }
        }
        public Inventory Inventory { get; set; }
        public string Name { get; set; }
        private int _level;
        public int Level
        {
            get { return _level; }
            private set
            {
                if (value < 1)
                {
                    _level = 1;
                }
                _level = value;
            }
        }

        private int _experience;
        public int Experience
        {
            get { return _experience; }
            set
            {
                if (value < 0)
                {
                    _experience = 0;
                }
 
                _experience = value;
  
                while (_experience >= Level * _levelUpValue + _currentLevelExperienceValue)
                {
                    _currentLevelExperienceValue = Level * _levelUpValue + _currentLevelExperienceValue;
                    Level++;
                    OnLevelUpEvent?.Invoke();
                }
            }
        }

        private Characterictic _strength;
        public Characterictic Strength
        {
            get { return _strength; }
            private set
            {
                _strength = value;
                _charactericticChangedEvent?.Invoke();
            }
        }
        private double _strengthAttackChange;
        private double _strengthHealthChange;

        private Characterictic _dexterity;
        public Characterictic Dexterity
        {
            get { return _dexterity; }
            private set
            {
                _dexterity = value;
                _charactericticChangedEvent?.Invoke();
            }
        }
        private double _dexterityAttackChange;
        private double _dexterityPhysicalDefenceChange;

        private Characterictic _constitution;
        public Characterictic Constitution
        {
            get { return _constitution; }
            private set
            {
                _constitution = value;
                _charactericticChangedEvent?.Invoke();
            }
        }
        private double _constitutionHealthChange;
        private double _constitutionPhysicalDefenceChange;

        private Characterictic _intellisense;
        public Characterictic Intellisense
        {
            get { return _intellisense; }
            private set
            {
                _intellisense = value;
                _charactericticChangedEvent?.Invoke();
            }
        }
        private double _intellisenseManaChange;
        private double _intellisenseMagicalAttackChange;

        private double _mana;
        public double Mana
        {
            get { return _mana; }
            private set
            {
                if (value <= 0)
                {
                    _mana = 0;
                }
                _mana = value;
            }
        }

        private double _attackDamage;
        public double AttackDamage
        {
            get { return _attackDamage; }
            private set
            {
                if (value <= 0)
                {
                    _attackDamage = 0;
                }
                _attackDamage = value;
            }
        }

        private double _health;
        public double Health
        {
            get { return _health; }
            private set
            {
                if (value <= 0)
                {
                    _health = 0;
                }
                _health = value;
            }
        }

        private double _physicalDefense;
        public double PhysicalDefense
        {
            get { return _physicalDefense; }
            private set
            {
                if (value <= 0)
                {
                    _physicalDefense = 0;
                }
                _physicalDefense = value;
            }
        }

        private double _magicalAttackDamage;
        public double MagicalAttackDamage
        {
            get { return _magicalAttackDamage; }
            private set
            {
                if (value <= 0)
                {
                    _magicalAttackDamage = 0;
                }
                _magicalAttackDamage = value;
            }
        }

        private void CalculateCharacterictics()
        {
            AttackDamage = Strength.Value * _strengthAttackChange + 
                           Dexterity.Value * _dexterityAttackChange;
            Health = Constitution.Value * _constitutionHealthChange + 
                        Strength.Value * _strengthHealthChange;
            PhysicalDefense = Constitution.Value * _constitutionPhysicalDefenceChange + 
                                Dexterity.Value * _dexterityPhysicalDefenceChange;
            Mana = Intellisense.Value * _intellisenseManaChange;
            MagicalAttackDamage = Intellisense.Value * _intellisenseMagicalAttackChange;

            FillAllAbilityData();
        }

        public void SetStrengthValue(int value)
        {
            Strength.Value = value;
            _charactericticChangedEvent?.Invoke();
        }

        public int GetStrengthValue()
        {
            return _strength.Value;
        }

        public void SetDexterityValue(int value)
        {
            Dexterity.Value = value;
            _charactericticChangedEvent?.Invoke();
        }

        public int GetDexterityValue()
        {
            return _dexterity.Value;
        }

        public void SetConstitutionValue(int value)
        {
            Constitution.Value = value;
            _charactericticChangedEvent?.Invoke();
        }

        public int GetConstitutionValue()
        {
            return _constitution.Value;
        }

        public void SetIntellisenseValue(int value)
        {
            Intellisense.Value = value;
            _charactericticChangedEvent?.Invoke();
        }

        public int GetIntellisenseValue()
        {
            return _intellisense.Value;
        }

        private void UpdateCharacterictics()
        {
            SetStrengthValue(Strength.Value + 5);
            SetDexterityValue(Dexterity.Value + 5);
            SetConstitutionValue(Constitution.Value + 5);
            SetIntellisenseValue(Intellisense.Value + 5);
            _charactericticChangedEvent?.Invoke();
        }

        private void FillAbilityData(Ability ability)
        {
            AttackDamage += ability.AttackChangeValue;
            Health += ability.HealthChangeValue;
            PhysicalDefense += ability.PhysicalDefenceChangeValue;
            Mana += ability.ManaChangeValue;
            MagicalAttackDamage += ability.MagicalAttackChangeValue;
        }
        private void FillAllAbilityData()
        {
            foreach (var ability in _abilities)
            {
                FillAbilityData(ability);
            }
        }

        public bool AddAbility(Ability ability)
        {
            if (ability == null)
            {
                return false;
            }

            if (_availableAbilityCount > 0)
            {
                _availableAbilityCount--;
                Abilities.Add(ability);
                FillAbilityData(ability);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void CheckLevel()
        {
            if (Level % 3 == 0)
            {
                _availableAbilityCount++;
            }
        }

        protected Character(Characterictic strength,
                            double strengthAttackChange,
                            double strengthHealthChange,
                            Characterictic dexterity,
                            double dexterityAttackChange,
                            double dexterityPhysicalDefenceChange,
                            Characterictic constitution,
                            double constitutionHealthChange,
                            double constitutionPhysicalDefenceChange,
                            Characterictic intellisense,
                            double intellisenseManaChange,
                            double intellisenseMagicalAttackChange,
                            int experience,
                            int availableAbilityCount)
        {
            Level = 1;
            Experience = experience;
            AvailableAbilityCount = availableAbilityCount;
            _abilities = new List<Ability>();

            _strengthAttackChange = strengthAttackChange;
            _strengthHealthChange = strengthHealthChange;
            Strength = strength;

            _dexterityAttackChange = dexterityAttackChange;
            _dexterityPhysicalDefenceChange = dexterityPhysicalDefenceChange;
            Dexterity = dexterity;

            _constitutionHealthChange = constitutionHealthChange;
            _constitutionPhysicalDefenceChange = constitutionPhysicalDefenceChange;
            Constitution = constitution;

            _intellisenseMagicalAttackChange = intellisenseMagicalAttackChange;
            _intellisenseManaChange = intellisenseManaChange;
            Intellisense = intellisense;

            Inventory = new Inventory();

            OnLevelUpEvent += UpdateCharacterictics;
            OnLevelUpEvent += CheckLevel;
            _charactericticChangedEvent += CalculateCharacterictics;
            _charactericticChangedEvent?.Invoke();
        }
    }
}