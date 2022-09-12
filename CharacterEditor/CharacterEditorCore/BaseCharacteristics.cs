namespace CharacterEditorCore
{
    public abstract class BaseCharacteristics
    {
        private int _expPoints;
        public int ExpPoints
        {
            get { return _expPoints; }
            set { _expPoints = value; }
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
                _expPoints -= value.Value - _dexterity.Value;
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
                _expPoints -= value.Value - _dexterity.Value;
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
                _expPoints -= value.Value - _dexterity.Value;
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

        public void AttackDamageCalc()
        {
            AttackDamage = _strength.Value * _strengthAttackChange + _dexterity.Value * _dexterityAttackChange;
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

        public void PhysicalDefCalc()
        {
            PhysicalDef = _dexterity.Value * _dexterityPhysicalDefChange + _constitution.Value * _constitutionPhysicalDefChange;
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
        public void MagicAttackCalc()
        {
            MagicAttack = _intelligence.Value * _intelligenceMagicAttackChange;
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
        public void ManaPointCalc()
        {
            ManaPoint = _intelligence.Value * _intelligenceMpChange;
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
        public void HealthPointCalc()
        {
            HealthPoint = _strength.Value * _strengthHpChange + _constitution.Value * _constitutionHpChange;
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
                                double intelligenceMpChange,
                                int expPoints)
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
            _expPoints = expPoints;
            
            CalcStats();
        }
    }
}
