using WeaponGame.Interfaces;

namespace WeaponGame.Weapons
{
    public class Knife : IMeleeWeapon, IThrowable
    {
        private ILogger _logger;
        private int _meleeDamage;
        public int MeleeDamage
        {
            get { return _meleeDamage; }
            set
            {
                if (value <= 0)
                {
                    _meleeDamage = 0;
                }
                _meleeDamage = value;
            }
        }

        private int _throwDamage;
        public int ThrowDamage
        {
            get { return _throwDamage; }
            set
            {
                if (value <= 0)
                {
                    _throwDamage = 0;
                }
                _throwDamage = value;
            }
        }

        private int _durability;
        public int Durability
        {
            get { return _durability; }
            set
            {
                if (value <= 0)
                {
                    _durability = 0;
                }
                _durability = value;
            }
        }

        public Knife(ILogger logger, int meleeDamage, int throwDamage, int durability)
        {
            _logger = logger;
            ThrowDamage = throwDamage;
            MeleeDamage = meleeDamage;
            Durability = durability;
        }

        private void Log(string message)
        {
            _logger.Log(message);
        }

        public void MeleeAttack()
        {
            Log($"{GetType().Name} attack with damage: {MeleeDamage}");
        }

        public void Throw()
        {
            Log($"{GetType().Name} throw with damage: {ThrowDamage}");
        }

        public void Repair()
        {
            Durability += 7;
            Log($"{GetType().Name} was repaired. Durability: {Durability}");
        }

        public void Upgrade()
        {
            MeleeDamage += 5;
            ThrowDamage += 10;
            Log($"{GetType().Name} was upgraded." +
                $" Melee Damage: {MeleeDamage}," +
                $"ThrowDamage: {ThrowDamage}");
        }
    }
}