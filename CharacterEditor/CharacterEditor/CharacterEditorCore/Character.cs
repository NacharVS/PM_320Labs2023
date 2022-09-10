namespace CharacterEditorCore
{
    abstract class Character
    {
        public Characterictic Strength { get; set; }
        private double _strengthAttackChange;
        private double _strengthHealthChange;
        public Characterictic Dexterity { get; set; }
        private double _dexterityAttackChange;
        private double _dexterityPhysicalDefenceChange;
        public Characterictic Constitution { get; set; }
        private double _constitutionHealthChange;
        private double _constitutionPhysicalDefenceChange;
        public Characterictic Intellisense { get; set; }
        private double _intellisenseManaChange;
        private double _intellisenseMagicalAttackChange;

        public int Mana
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
        public int AttackDamage
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

        public int Health
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

        public int PhysicalDefence
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

        public int MagicalAttackDamage
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
    }
}