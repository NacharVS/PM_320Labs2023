namespace CharacterEditorCore
{
    public abstract class Character
    {
        private Characterictic _strength;
        private double _strengthAttackChange;
        private double _strengthHealthChange;

        private Characterictic _dexterity;
        private double _dexterityAttackChange;
        private double _dexterityPhysicalDefenceChange;

        private Characterictic _constitution;
        private double _constitutionHealthChange;
        private double _constitutionPhysicalDefenceChange;

        private Characterictic _intellisense;
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

        private double _physicalDefence;
        public double PhysicalDefence
        {
            get { return _physicalDefence; }
            private set
            {
                if (value <= 0)
                {
                    _physicalDefence = 0;
                }
                _physicalDefence = value;
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

        public void SetStrengthValue(int value)
        {
            _strength.Value = value;

            AttackDamage += _strength.Value * _strengthAttackChange;
            Health += _strength.Value * _strengthHealthChange;
        }

        public double GetStrengthValue()
        {
            return _strength.Value;
        }

        public void SetDexterityValue(int value)
        {
            _dexterity.Value = value;

            AttackDamage += _dexterity.Value * _dexterityAttackChange;
            PhysicalDefence += _dexterity.Value * _dexterityPhysicalDefenceChange;
        }

        public double GetDexterityValue()
        {
            return _dexterity.Value;
        }

        public void SetConstitutionValue(int value)
        {
            _constitution.Value = value;

            Health += _constitution.Value * _constitutionHealthChange;
            PhysicalDefence += _constitution.Value * _constitutionPhysicalDefenceChange;
        }

        public double GetConstitutionValue()
        {
            return _constitution.Value;
        }

        public void SetIntellisenseValue(int value)
        {
            _intellisense.Value = value;

            Mana += _intellisense.Value * _intellisenseManaChange;
            MagicalAttackDamage += _intellisense.Value * _intellisenseMagicalAttackChange;
        }

        public double GetIntellisenseValue()
        {
            return _intellisense.Value;
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
                            double intellisenseMagicalAttackChange)
        {
            _strength = strength;
            _strengthAttackChange = strengthAttackChange;
            _strengthHealthChange = strengthHealthChange;
            SetStrengthValue(_strength.Value);

            _dexterity = dexterity;
            _dexterityAttackChange = dexterityAttackChange;
            _dexterityPhysicalDefenceChange = dexterityPhysicalDefenceChange;
            SetDexterityValue(_dexterity.Value);

            _constitution = constitution;
            _constitutionHealthChange = constitutionHealthChange;
            _constitutionPhysicalDefenceChange = constitutionPhysicalDefenceChange;
            SetConstitutionValue(_constitution.Value);

            _intellisense = intellisense;
            _intellisenseMagicalAttackChange = intellisenseMagicalAttackChange;
            _intellisenseManaChange = intellisenseManaChange;
            SetIntellisenseValue(_intellisense.Value);
        }
    }
}