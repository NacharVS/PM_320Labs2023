using WeaponGame.Interfaces;

namespace WeaponGame.Weapons
{
    public class Shuriken : IThrowable
    {
        private ILogger _logger;
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

        public Shuriken(ILogger logger, int damage)
        {
            _logger = logger;
            ThrowDamage = damage;
        }

        private void Log(string message)
        {
            _logger.Log(message);
        }

        public void Throw()
        {
            Log($"{GetType().Name} throw with damage: {ThrowDamage}");
        }
    }
}