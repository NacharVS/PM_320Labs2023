namespace WPFcharacterictic.Core
{
    public abstract class Entity
    {
        public delegate void ChangedСharacteristics();
        //int values
        public int MaxStrength;
        public int MinStrength;
        public int MaxDexterity;
        public int MinDexterity;
        public int MaxConstitution;
        public int MinConstitution;
        public int MaxIntelligence;
        public int MinIntelligence;
        public int AvailablePoints = 300;

        public int Strength;
        public int Dexterity;
        public int Constitution;
        public int Intelligence;

        //
        protected int _health;
        public int Health 
        { 
            get { return _health; }
            private protected set { _health = value; }
        }
        protected double _mana;
        public double Mana
        {
            get { return _mana; }
            private protected set { _mana = value; }
        }
        protected double _physicalAttack;
        public double PhysicalAttack
        {
            get { return _physicalAttack; }
            private protected set { _physicalAttack = value; }
        }
        protected double _magicAttack;
        public double MagicAttack
        {
            get { return _magicAttack; }
            private protected set { _magicAttack = value; }
        }
        public double _physicalDefense;
        public double PhysicalDefense
        {
            get { return _physicalDefense; }
            private protected set { _physicalDefense = value; }
        }
        public double _magicDefense;
        public double MagicDefense
        {
            get { return _magicDefense; }
            private protected set { _magicDefense = value; }
        }

        public Entity()
        {
            Health = 0;
            Mana = 0;
            PhysicalAttack = 0;
            MagicAttack = 0;
            PhysicalDefense = 0;
            MagicDefense = 0;
        }

        public virtual void IncreasedStrength() 
        {
        }
        public virtual void IncreasedDexterity()
        {
        }
        public virtual void IncreasedConstitution()
        {
        }
        public virtual void IncreasedIntelligence()
        {
        }
    }
}