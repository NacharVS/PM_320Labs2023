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

        private int _attackDamage;
        public int AttackDamage
        {
            get { return _attackDamage; }
            set
            {
                if(value >= 0)
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

        private List<IItem> _inventory = new();

        public List<IItem> Inventory
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

        public void AddItem(IItem item)
        {
            _inventory.Add(item);
        }

        public void RemoveItem(IItem item)
        {
            _inventory.Remove(item);
        }
        public void HealthPointCalc()
        {
            HealthPoint = _strength.Value * _strengthHpChange + _constitution.Value * _constitutionHpChange;
        }

        public void AttackDamageCalc()
        {
            AttackDamage = _strength.Value * _strengthAttackChange + _dexterity.Value * _dexterityAttackChange;
        }
        public void ManaPointCalc()
        {
            ManaPoint = _intelligence.Value * _intelligenceMpChange;
        }
        public void MagicAttackCalc()
        {
            MagicAttack = _intelligence.Value * _intelligenceMagicAttackChange;
        }
        public void PhysicalDefCalc()
        {
            PhysicalDef = _dexterity.Value * _dexterityPhysicalDefChange + _constitution.Value * _constitutionPhysicalDefChange;
        }

        public void CalcStats()
        {
            AttackDamageCalc();
            HealthPointCalc();
            ManaPointCalc();
            MagicAttackCalc();
            PhysicalDefCalc();
        }

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

            CalcStats();
        }
    }
}
