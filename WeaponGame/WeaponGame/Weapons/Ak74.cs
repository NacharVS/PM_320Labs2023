using WeaponGame.Interfaces;

namespace WeaponGame.Weapons
{
    public class Ak74 : IWeapon, ITripleShoot
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

        private int _tripleShootDamage;
        public int TripleShootDamage
        {
            get { return _tripleShootDamage; }
            set
            {
                if (value <= 0)
                {
                    _tripleShootDamage = 0;
                }
                _tripleShootDamage = value;
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

        public Ak74(ILogger logger, int damage, int tripleShootDamage, int durability)
        {
            _logger = logger;
            TripleShootDamage = tripleShootDamage;
            Damage = damage;
            Durability = durability;
        }

        private void Log(string message)
        {
            _logger.Log(message);
        }

        public void SingleShoot()
        {
            if (IsHaveDurability())
            {
                Log($"{GetType().Name} fired a single shoot with damage: {Damage}");
            }
        }

        public void TripleShoot()
        {
            if (IsHaveDurability())
            {
                Log($"{GetType().Name} fired a triple shoot with damage: {TripleShootDamage}");
            }
        }

        public void Reload()
        {
            Log($"{GetType().Name} was reloaded.");
        }

        public void Repair()
        {
            Durability += 10;
            Log($"{GetType().Name} was repaired. Durability: {Durability}");
        }

        public void Upgrade()
        {
            Damage += 20;
            TripleShootDamage += 30;
            Log($"{GetType().Name} was upgraded. " +
                $"Single shoot damage: {Damage}, " +
                $"Triple shoot damage: {TripleShootDamage}");
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