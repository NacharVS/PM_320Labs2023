namespace CharacterEditorCore
{
    public abstract class Character
    {
        private Characterictic _strength;
        public Characterictic Strength
        {
            get { return _strength; }
            private set
            {
                _strength = value;
                AttackDamage += _strength.Value * _strengthAttackChange;
                Health += _strength.Value * _strengthHealthChange;
            }
        }
        private double _strengthAttackChange;
        private double _strengthHealthChange;

        private Characterictic _dexterity;
        public Characterictic Dexterity
        {
            get { return _strength; }
            private set
            {
                _dexterity = value;
                AttackDamage += _dexterity.Value * _dexterityAttackChange;
                PhysicalDefence += _dexterity.Value * _dexterityPhysicalDefenceChange;
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
                Health += _constitution.Value * _constitutionHealthChange;
                PhysicalDefence += _constitution.Value * _constitutionPhysicalDefenceChange;
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
                Mana += _intellisense.Value * _intellisenseManaChange;
                MagicalAttackDamage += _intellisense.Value * _intellisenseMagicalAttackChange;
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

        private int GetDifference(int value, Characterictic characterictic)
        {
            var previousValue = characterictic.Value;
            characterictic.Value = value;
            return characterictic.Value - previousValue;
        }

        public void SetStrengthValue(int value)
        {
            var difference = GetDifference(value, Strength);

            if (difference > 0)
            {
                AttackDamage += difference * _strengthAttackChange;
                Health += difference * _strengthHealthChange;
            }
            else if (difference < 0)
            {
                var difModule = Math.Abs(difference);
                AttackDamage -= difModule * _strengthAttackChange;
                Health -= difModule * _strengthHealthChange;
            }
        }

        public double GetStrengthValue()
        {
            return _strength.Value;
        }

        public void SetDexterityValue(int value)
        {
            var difference = GetDifference(value, Dexterity);

            if (difference > 0)
            {
                AttackDamage += difference * _dexterityAttackChange;
                PhysicalDefence += difference * _dexterityPhysicalDefenceChange;
            }
            else if (difference < 0)
            {
                var difModule = Math.Abs(difference);
                AttackDamage -= difModule * _dexterityAttackChange;
                PhysicalDefence -= difModule * _dexterityPhysicalDefenceChange;
            }
        }

        public double GetDexterityValue()
        {
            return _dexterity.Value;
        }

        public void SetConstitutionValue(int value)
        {
            var difference = GetDifference(value, Constitution);

            if (difference > 0)
            {
                Health += difference * _constitutionHealthChange;
                PhysicalDefence += difference * _constitutionPhysicalDefenceChange;
            }
            else if (difference < 0)
            {
                var difModule = Math.Abs(difference);
                Health -= difModule * _constitutionHealthChange;
                PhysicalDefence -= difModule * _constitutionPhysicalDefenceChange;
            }
        }

        public double GetConstitutionValue()
        {
            return _constitution.Value;
        }

        public void SetIntellisenseValue(int value)
        {
            var difference = GetDifference(value, Intellisense);

            if (difference > 0)
            {
                Mana += difference * _intellisenseManaChange;
                MagicalAttackDamage += difference * _intellisenseMagicalAttackChange;
            }
            else if (difference < 0)
            {
                var difModule = Math.Abs(difference);
                Mana -= difModule * _intellisenseManaChange;
                MagicalAttackDamage -= difModule * _intellisenseMagicalAttackChange;
            }
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
        }
    }
}