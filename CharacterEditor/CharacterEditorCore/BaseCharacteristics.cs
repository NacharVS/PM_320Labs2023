using CharacterEditorCore.Items;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CharacterEditorCore
{
    public abstract class BaseCharacteristics
    {
        private string _name;
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        private delegate void AbilityAddDelegate(Ability ability);
        private delegate void ItemChangeDelegate(Item item, int changeType);

        #region Characteristics
        private Characteristics _strength;
        public Characteristics Strength {
            get { return _strength; }
            set
            {
                _strength = value;
            }
        }
        protected int _strengthAttackChange;
        protected int _strengthHpChange;

        private Characteristics _dexterity;
        public Characteristics Dexterity {
            get { return _dexterity; }
            set
            {
                _dexterity = value;
            }
        }
        protected int _dexterityAttackChange;
        protected double _dexterityPhysicalDefChange;

        private Characteristics _constitution;
        public Characteristics Constitution
        {
            get
            {
                return _constitution;
            }
            set
            {
                _constitution = value;
            }
        }

        protected int _constitutionHpChange;
        protected double _constitutionPhysicalDefChange;

        private Characteristics _intelligence;
        public Characteristics Intelligence
        {
            get { return _intelligence; }
            set
            {
                _intelligence = value;
            }
        }
        protected double _intelligenceMpChange;
        protected int _intelligenceMagicAttackChange;

        private Level _lvl = new();

        public Level Lvl
        {
            get => _lvl;
            set => _lvl = value;
        }
        #endregion

        #region Stats
        private int _lvlCharacteristicsChangeVal = 5;
        private int _attackDamage;
        public int AttackDamage
        {
            get { return _attackDamage; }
            set
            {
                if (value >= 0)
                {
                    _attackDamage = value;
                }
                else _attackDamage = 0;
            }
        }

        private double _physicalDef;
        public double PhysicalDef
        {
            get { return _physicalDef; }
            set
            {
                if (value >= 0)
                {
                    _physicalDef = value;
                }
                else _physicalDef = 0;
            }
        }

        private int _magicAttack;
        public int MagicAttack
        {
            get { return _magicAttack; }
            set
            {
                if (value >= 0)
                {
                    _magicAttack = value;
                }
                else _magicAttack = 0;
            }
        }

        private double _mp;
        public double ManaPoint
        {
            get { return _mp; }
            set
            {
                if (value >= 0)
                {
                    _mp = value;
                }
                else _mp = 0;
            }
        }
        private int _hp;
        public int HealthPoint
        {
            get { return _hp; }
            set
            {
                if (value >= 0)
                {
                    _hp = value;
                }
                else _hp = 0;
            }
        }
        #endregion

        #region Inventory
        private int _inventCapacity = 10;
        public int InventCapacity
        {
            get => _inventCapacity;
            private set => _inventCapacity = value;
        }
        private List<Item> _inventory;
        public List<Item> Inventory
        {
            get => _inventory;
            set
            {
                foreach (var item in value)
                {
                    AddItem(item);
                }
            }
        }
        public void AddItem(Item item)
        {
            if (_inventory.Count < _inventCapacity && Lvl.CurrentLevel >= item.MinimumLevel)
            {
                _inventory.Add(item);
                OnItemChangeEvent?.Invoke(item,1); // Add item in inventory type - 1
            }
        }
        public void RemoveItem(Item item)
        {
            _inventory.Remove(item);
            OnItemChangeEvent?.Invoke(item, -1);// Add item in inventory type - (-1)
        }

        public void AddItemStat(Item item, int changeType)
        {
            HealthPoint += item.HPChange * changeType;
            AttackDamage += item.AttackChange * changeType;
            ManaPoint += item.ManaChange * changeType;
            MagicAttack += item.MagicalAttackChange * changeType;
            PhysicalDef += item.PdefChange * changeType;
        }
        private void ItemStatsCalc()
        {
            foreach (var item in _inventory)
            {
                AddItemStat(item,1);
            }
        }
        #endregion

        #region Abilities
        private int _abilitiesCapacity = 5;
        private List<Ability> _abilities;
        public List<Ability> Abilities
        {
            get => _abilities;
            set
            {
                foreach (var ability in value)
                {
                    AddAbility(ability);
                }
            }
        }
        public void AddAbility(Ability ability)
        {
            if (_abilities.Count < _abilitiesCapacity)
            {
                _abilities.Add(ability);
                OnAbilityAddEvent?.Invoke(ability);
            }
        }
        private void AddAbilityStats(Ability ability)
        {
            HealthPoint += ability.HealthChange;
            ManaPoint += ability.ManaChange;
            AttackDamage += ability.AttackChange;
            MagicAttack += ability.MagicalAttackChange;
            PhysicalDef += ability.PhysicalDefChange;
        }
        #endregion

        #region CalcStats

        public void SetDefStats()
        {
            HealthPoint = _strength.Value * _strengthHpChange + _constitution.Value * _constitutionHpChange;
            AttackDamage = _strength.Value * _strengthAttackChange + _dexterity.Value * _dexterityAttackChange;
            ManaPoint = _intelligence.Value * _intelligenceMpChange;
            MagicAttack = _intelligence.Value * _intelligenceMagicAttackChange;
            PhysicalDef = _dexterity.Value * _dexterityAttackChange + _constitution.Value * _constitutionPhysicalDefChange;

            AbilityStatsCalc();
            ItemStatsCalc();
        }
        private void AbilityStatsCalc()
        {
            foreach (var ab in _abilities)
            {
                AddAbilityStats(ab);
            }
        }
        public void AddCharacteristics()
        {
            Constitution.Value += _lvlCharacteristicsChangeVal;
            Intelligence.Value += _lvlCharacteristicsChangeVal;
            Dexterity.Value += _lvlCharacteristicsChangeVal;
            Strength.Value += _lvlCharacteristicsChangeVal;

            SetDefStats();
        }
        #endregion

        public BaseCharacteristics(Characteristics strength,
                                Characteristics dexterity,
                                Characteristics constitution,
                                Characteristics intelligense,
                                int strengthHpChange,
                                int strengthAttackChange,
                                double dexterityPhysicalDefChange,
                                int dexterityAttackChange,
                                double constitutionPhysicalDefChange,
                                int constitutionHpChange,
                                int intelligenceMagicAttackChange,
                                double intelligenceMpChange)
        {
            _strength = strength;
            _dexterity = dexterity;
            _constitution = constitution;
            _intelligence = intelligense;
            _strengthHpChange = strengthHpChange;
            _strengthAttackChange = strengthAttackChange;
            _dexterityAttackChange = dexterityAttackChange;
            _dexterityPhysicalDefChange = dexterityPhysicalDefChange;
            _constitutionHpChange = constitutionHpChange;
            _constitutionPhysicalDefChange = constitutionPhysicalDefChange;
            _intelligenceMagicAttackChange = intelligenceMagicAttackChange;
            _intelligenceMpChange = intelligenceMpChange;

            _inventory = new();
            _abilities = new();

            OnAbilityAddEvent +=AddAbilityStats;
            OnItemChangeEvent += AddItemStat;
            SetDefStats();
        }

        private event AbilityAddDelegate OnAbilityAddEvent;
        private event ItemChangeDelegate OnItemChangeEvent;
    }
}
