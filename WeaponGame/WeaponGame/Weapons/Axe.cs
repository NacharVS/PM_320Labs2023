using WeaponGame.Interfaces;

namespace WeaponGame.Weapons
{
    public class Axe : IMeleeWeapon
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

        public Axe(ILogger logger, int meleeDamage, int durability)
        {
            _logger = logger;
            MeleeDamage = meleeDamage;
            Durability = durability;
        }

        private void Log(string message)
        {
            _logger.Log(message);
        }

        public void MeleeAttack()
        {
            if(IsHaveDurability())
            {
                Log($"{GetType().Name} attack with damage: {MeleeDamage}");
            }
        }

        public void Repair()
        {
            Durability += 4;
            Log($"{GetType().Name} was repaired. Durability: {Durability}");
        }

        public void Upgrade()
        {
            MeleeDamage += 15;
            Log($"{GetType().Name} was upgraded. Damage: {MeleeDamage}");
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