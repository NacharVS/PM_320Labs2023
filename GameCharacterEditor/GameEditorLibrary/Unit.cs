using System;

namespace GameEditorLibrary
{
    public class Unit
    {
        public int minStrength { get; set; }
        public int maxStrength;
        private int _strength;
        public int strength
        {
            get { return _strength; }
            set
            {
                _strength = value;
            }
        }
        public int minDexterity;
        public int maxDexterity;
        private int _dexterity;
        public int dexterity
        {
            get { return _dexterity; }
            set
            {
                _dexterity = value;
            }
        }
        public int minConstitution;
        public int maxConstitution;
        private int _constitution;
        public int constitution
        {
            get { return _constitution; }
            set
            {
                _constitution = value;
            }
        }
        public int minIntelligence;
        public int maxIintelligence;
        private int _intelligence;
        public int intelligence
        {
            get { return _intelligence; }
            set
            {
                _intelligence = value;
            }
        }
        public int attackDamage;
        public int manaAttack;
        public double phDefention;
        public double HP;
        public double MP;

        public Unit() { }
    }
}