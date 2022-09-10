namespace CharacterEditorCore
{
    public abstract class Character
    {
        private Characterictic _strength;
        private double _strengthAttackChange;
        private double _strengthHealthChange;

        private Characterictic _dexterity;
        private double _dexterityAttackChange;
        protected double _dexterityPhysicalDefenceChange;

        private Characterictic _constitution;
        private double _constitutionHealthChange;
        private double _constitutionPhysicalDefenceChange;

        private Characterictic _intellisense;
        private double _intellisenseManaChange;
        private double _intellisenseMagicalAttackChange;

        public double Mana
        {
            get { return Mana; }
            set
            {
                if (value <= 0)
                {
                    Mana = 0;
                }
                Mana = value;
            }
        }
        public double AttackDamage
        {
            get { return AttackDamage; }
            set
            {
                if (value <= 0)
                {
                    AttackDamage = 0;
                }
                AttackDamage = value;
            }
        }

        public double Health
        {
            get { return Health; }
            set
            {
                if (value <= 0)
                {
                    Health = 0;
                }
                Health = value;
            }
        }

        public double PhysicalDefence
        {
            get { return PhysicalDefence; }
            set
            {
                if (value <= 0)
                {
                    PhysicalDefence = 0;
                }
                PhysicalDefence = value;
            }
        }

        public double MagicalAttackDamage
        {
            get { return MagicalAttackDamage; }
            set
            {
                if (value <= 0)
                {
                    MagicalAttackDamage = 0;
                }
                MagicalAttackDamage = value;
            }
        }

        public void SetStrength(int value)
        {
            _strength.Value = value;

            AttackDamage = _strength.Value * _strengthAttackChange;
            Health = _strength.Value * _strengthHealthChange;
        }

        public double GetStrength()
        {
            return _strength.Value;
        }

        public void SetDexterity(int value)
        {
            _dexterity.Value = value;

            AttackDamage = _dexterity.Value * _dexterityAttackChange;
            PhysicalDefence = _dexterity.Value * _dexterityPhysicalDefenceChange;
        }

        public double GetDexterity()
        {
            return _dexterity.Value;
        }

        public void SetConstitution(int value)
        {
            _constitution.Value = value;

            Health = _constitution.Value * _constitutionHealthChange;
            PhysicalDefence = _constitution.Value * _constitutionPhysicalDefenceChange;
        }

        public double GetConstitution()
        {
            return _constitution.Value;
        }

        public void SetIntellisense(int value)
        {
            _intellisense.Value = value;

            Mana = _intellisense.Value * _intellisenseManaChange;
            MagicalAttackDamage = _intellisense.Value * _intellisenseMagicalAttackChange;
        }

        public double GetIntellisense()
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
            SetStrength(_strength.Value);
            _strengthAttackChange = strengthAttackChange;
            _strengthHealthChange = strengthHealthChange;

            _dexterity = dexterity;
            SetDexterity(_dexterity.Value);
            _dexterityAttackChange = dexterityAttackChange;
            _dexterityPhysicalDefenceChange = dexterityPhysicalDefenceChange;

            _constitution = constitution;
            SetConstitution(_constitution.Value);
            _constitutionHealthChange = constitutionHealthChange;
            _constitutionPhysicalDefenceChange = constitutionPhysicalDefenceChange;

            _intellisense = intellisense;
            SetIntellisense(_intellisense.Value);
            _intellisenseMagicalAttackChange = intellisenseMagicalAttackChange;
            _intellisenseManaChange = intellisenseManaChange;
        }
    }
}