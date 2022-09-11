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
        public int Health;
        public int AvailablePoints = 5;

        public int Strength;
        public int Dexterity;
        public int Constitution;
        public int Intelligence;

        //double values
        public double Mana;
        public double PhysicalAttack;
        public double MagicAttack;
        public double PhysicalDefense;
        public double MagicDefense;

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