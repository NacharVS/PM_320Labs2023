using CharacterEditorCore.Items;

namespace CharacterEditorCore
{
    public abstract class Character
    {
        private const int _levelUpValue = 1000;
        private delegate void _charactericticChangedDelegate();
        private _charactericticChangedDelegate _charactericticChangedEvent;
        private int _currentLevelExperienceValue = 0;
        private delegate void OnLevelUp();
        private  OnLevelUp OnLevelUpEvent;

        public string Name { get; set; }

        private List<Ability> _abilities;
        public List<Ability> Abilities
        {
            get { return _abilities; }
            set
            {
                foreach (var ability in value)
                {
                    _abilities.Add(ability);
                }
            }
        }

        private Equipment _equipment;
        public Equipment Equipment
        {
            get { return _equipment; }
            set
            {
                _equipment.Weapon = value.Weapon;
                _equipment.Breastplate = value.Breastplate;
                _equipment.Helmet = value.Helmet;
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
        public double StrengthAttackChange { get; private set; }
        public double StrengthHealthChange { get; private set; }

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
        public double DexterityAttackChange { get; private set; }
        public double DexterityPhysicalDefenceChange { get; private set; }

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
        public double ConstitutionHealthChange { get; private set; }
        public double ConstitutionPhysicalDefenceChange { get; private set; }

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
        public double IntellisenseManaChange { get; private set; }
        public double IntellisenseMagicalAttackChange { get; private set; }

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
            AttackDamage = Strength.Value * StrengthAttackChange +
                           Dexterity.Value * DexterityAttackChange;
            Health = Constitution.Value * ConstitutionHealthChange +
                        Strength.Value * StrengthHealthChange;
            PhysicalDefense = Constitution.Value * ConstitutionPhysicalDefenceChange +
                                Dexterity.Value * DexterityPhysicalDefenceChange;
            Mana = Intellisense.Value * IntellisenseManaChange;
            MagicalAttackDamage = Intellisense.Value * IntellisenseMagicalAttackChange;
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

        public int GetLevelCharactericticsValue()
        {
            return Level * 5;
        }

        public double GetAbilitiesAttackDamage()
        {
            double sum = 0;
            foreach (var ability in _abilities)
            {
                sum += ability.AttackChangeValue;
            }

            return sum;
        }

        public double GetAbilitiesHealth()
        {
            double sum = 0;
            foreach (var ability in _abilities)
            {
                sum += ability.HealthChangeValue;
            }

            return sum;
        }

        public double GetAbilitiesPhysicalDefense()
        {
            double sum = 0;
            foreach (var ability in _abilities)
            {
                sum += ability.PhysicalDefenceChangeValue;
            }

            return sum;
        }

        public double GetAbilitiesMana()
        {
            double sum = 0;
            foreach (var ability in _abilities)
            {
                sum += ability.ManaChangeValue;
            }

            return sum;
        }

        public double GetAbilitiesMagicalAttack()
        {
            double sum = 0;
            foreach (var ability in _abilities)
            {
                sum += ability.MagicalAttackChangeValue;
            }

            return sum;
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

        public List<Helmet> GetAvailableHelmets()
        {
            List<Helmet> list = new List<Helmet>();

            foreach (var item in Inventory.Items)
            {
                if (item is Helmet && item.Rang <= Equipment.MaxAvailableHelmetRang)
                {
                    list.Add(item as Helmet);
                }
            }

            return list;
        }

        public List<Breastplate> GetAvailableBreastplates()
        {
            List<Breastplate> list = new List<Breastplate>();

            foreach (var item in Inventory.Items)
            {
                if (item is Breastplate && item.Rang <= Equipment.MaxAvailablBreastplateRang)
                {
                    list.Add(item as Breastplate);
                }
            }

            return list;
        }

        public List<Weapon> GetAvailableWeapons()
        {
            List<Weapon> list = new List<Weapon>();

            foreach (var item in Inventory.Items)
            {
                if (item is Weapon && item.Rang <= Equipment.MaxAvailableWeaponRang)
                {
                    list.Add(item as Weapon);
                }
            }

            return list;
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

            StrengthAttackChange = strengthAttackChange;
            StrengthHealthChange = strengthHealthChange;
            Strength = strength;

            DexterityAttackChange = dexterityAttackChange;
            DexterityPhysicalDefenceChange = dexterityPhysicalDefenceChange;
            Dexterity = dexterity;

            ConstitutionHealthChange = constitutionHealthChange;
            ConstitutionPhysicalDefenceChange = constitutionPhysicalDefenceChange;
            Constitution = constitution;

            IntellisenseMagicalAttackChange = intellisenseMagicalAttackChange;
            IntellisenseManaChange = intellisenseManaChange;
            Intellisense = intellisense;

            Inventory = new Inventory();

            _charactericticChangedEvent += CalculateCharacterictics;
            _charactericticChangedEvent?.Invoke();
            OnLevelUpEvent += CheckLevel;
        }
    }
}