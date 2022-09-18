namespace CharacterEditorCore
{
    public abstract class Character
    {
        private delegate void _charactericticChangedDelegate();
        private _charactericticChangedDelegate _charactericticChangedEvent;
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
        }

        public void SetStrengthValue(int value)
        {
            Strength.Value = value;
            _charactericticChangedEvent?.Invoke();
        }

        public double GetStrengthValue()
        {
            return _strength.Value;
        }

        public void SetDexterityValue(int value)
        {
            Dexterity.Value = value;
            _charactericticChangedEvent?.Invoke();
        }

        public double GetDexterityValue()
        {
            return _dexterity.Value;
        }

        public void SetConstitutionValue(int value)
        {
            Constitution.Value = value;
            _charactericticChangedEvent?.Invoke();
        }

        public double GetConstitutionValue()
        {
            return _constitution.Value;
        }

        public void SetIntellisenseValue(int value)
        {
            Intellisense.Value = value;
            _charactericticChangedEvent?.Invoke();
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

            _charactericticChangedEvent += CalculateCharacterictics;
            _charactericticChangedEvent?.Invoke();
        }
    }
}