namespace CharacterEditorCore
{
    abstract class Character
    {
        public Characterictic Strength { get; set; }
        public Characterictic Dexterity { get; set; }
        public Characterictic Constitution { get; set; }
        public Characterictic Intellisense { get; set; }

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

        private int _attackChange;
        private int _healthChange;
        private int _physicalDefenceChange;
        private int _magicalAttackChange;

        protected Character(Characterictic strength, 
                            Characterictic dexterity, 
                            Characterictic constitution, 
                            Characterictic intellisense)
        {
            Strength = strength;
            Dexterity = dexterity;
            Constitution = constitution;
            Intellisense = intellisense;
        }
    }
}