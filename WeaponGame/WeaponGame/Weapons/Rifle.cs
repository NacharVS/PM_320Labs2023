using WeaponGame.Interfaces;

namespace WeaponGame
{
    public class Rifle : IWeapon
    {
        private ILogger _logger;
        private int _damage;
        public int Damage
        {
            get { return _damage; }
            set
            {
                if (value <= 0)
                {
                    _damage = 0;
                }
                _damage = value;
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

        public Rifle(ILogger logger, int damage, int durability)
        {
            _logger = logger;
            Damage = damage;
            Durability = durability;
        }

        private void Log(string message)
        {
            _logger.Log(message);
        }

        public void SingleShoot()
        {
            Log($"{GetType().Name} fired a single shoot with damage: {Damage}");
        }

        public void Reload()
        {
            Log($"{GetType().Name} was reloaded.");
        }

        public void Repair()
        {
            Durability += 5;
            Log($"{GetType().Name} was repaired. Durability: {Durability}");
        }

        public void Upgrade()
        {
            Damage += 10;
            Log($"{GetType().Name} was upgraded. Damage: {Damage}");
        }
    }
}