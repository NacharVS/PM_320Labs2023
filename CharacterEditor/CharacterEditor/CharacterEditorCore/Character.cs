namespace CharacterEditorCore
{
    public abstract class Character
    {
        public Characterictic Strength { get; set; }
        private double _strengthAttackChange;
        private double _strengthHealthChange;
        public Characterictic Dexterity { get; set; }
        private double _dexterityAttackChange;
        protected double _dexterityPhysicalDefenceChange;
        public Characterictic Constitution { get; set; }
        private double _constitutionHealthChange;
        private double _constitutionPhysicalDefenceChange;
        public Characterictic Intellisense { get; set; }
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
            Strength = strength;
            _strengthAttackChange = strengthAttackChange;
            _strengthHealthChange = strengthHealthChange;
            Dexterity = dexterity;
            _dexterityAttackChange = dexterityAttackChange;
            _dexterityPhysicalDefenceChange = dexterityPhysicalDefenceChange;
            Constitution = constitution;
            _constitutionHealthChange = constitutionHealthChange;
            _constitutionPhysicalDefenceChange = constitutionPhysicalDefenceChange;
            Intellisense = intellisense;
            _intellisenseMagicalAttackChange = intellisenseMagicalAttackChange;
            _intellisenseManaChange = intellisenseManaChange;
        }
    }
}