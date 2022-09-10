
namespace UnitsEditorCore
{
    abstract class BaseCharacteristics
    {
        private Characteristics _strength;
        private Characteristics _dexterity;
        private Characteristics _constitution;
        private Characteristics _intelligence;

        private int _attackDamage;
        public int AttackDamage
        {
            get { return _attackDamage; }
            set
            {
                if(value >= 0)
                {
                    _attackDamage = value;
                }
                else _attackDamage = 0;
            }
        }
        private double _physicalDef;
        public double PhysicalDef
        {
            get { return _physicalDef; }
            set
            {
                if (value >= 0)
                {
                    _physicalDef = value;
                }
                else _physicalDef = 0;
            }
        }
        private int _magicAttack;
        public int MagicAttack
        {
            get { return _magicAttack; }
            set
            {
                if (value >= 0)
                {
                    _magicAttack = value;
                }
                else _magicAttack = 0;
            }
        }
        private double _mp;
        public double ManaPoint
        {
            get { return _mp; }
            set
            {
                if (value >= 0)
                {
                    _mp = value;
                }
                else _mp = 0;
            }
        }
        private int _hp;
        public int HealthPoint
        {
            get { return _hp; }
            set
            {
                if (value >= 0)
                {
                    _hp = value;
                }
                else _hp = 0;
            }
        }
    }
}
