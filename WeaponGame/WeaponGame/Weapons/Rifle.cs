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

        private int _maxMagazineCapacity;
        public int MaxMagazineCapacity
        {
            get { return _maxMagazineCapacity; }
            private set
            {
                if (value <= 0)
                {
                    _maxMagazineCapacity = 0;
                }
                _maxMagazineCapacity = value;
            }
        }

        private int _magazineCapacity;
        public int MagazineCapacity
        {
            get { return _magazineCapacity; }
            private set
            {
                if (value <= MaxMagazineCapacity && value > 0)
                {
                    _magazineCapacity = value;
                }
                else if (value > MaxMagazineCapacity)
                {
                    _magazineCapacity = MaxMagazineCapacity;
                }
                _magazineCapacity = 0;
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
            if(IsHaveDurability())
            {
                Log($"{GetType().Name} fired a single shoot with damage: {Damage}");
            }          
        }

        public void Reload()
        {
            if(IsHaveDurability())
            {
                MagazineCapacity += 2;
                Log($"{GetType().Name} was reloaded.");
            }           
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

        private bool IsHaveDurability()
        {
            if (Durability == 0)
            {
                Log($"Can not fire!Durability {Durability}");
                return false;
            }
            return true;
        }
    }
}