namespace WarcraftGameCore
{
    public abstract class Unit
    {
        private Logger _logger;
        protected double _health;
        protected int _cost;
        protected String _name;
        protected int _level;
        protected bool _isDestroyed;
        protected double _maxHp;
        protected delegate void healthChangedDelegate(EventArgs args);

        public Unit(Logger logger, string name, double health, 
                    int cost, int level, double maxHp)
        {
            _logger = logger;
            _name = name;
            _health = health;
            _cost = cost;
            _level = level;
            _maxHp = maxHp;

            healthChangedEvent += CheckHpChange;
        }

        protected void Log(string message)
        {
            _logger.Log(message);
        }

        private void CheckHpChange(EventArgs args)
        {
            if (args is HealthChangedEventArgs hpArgs)
            {
                var changedHp = hpArgs.CurrentHp - hpArgs.PreviosHp;

                if (changedHp > 0)
                {
                    Log($"{this.GetName()} was healed. +{changedHp}hp");
                }
                else
                {
                    Log($"{this.GetName()} was damaged. {changedHp}hp");
                }
            } 
        }

        public double GetMaxHp()
        {
            return _maxHp;
        }

        public string GetName()
        {
            return _name;
        }

        public double GetHealth()
        {
            return _health;
        }

        public void SetHealth(double health)
        {
            var currentHp = _health;
            _health = health;

            healthChangedEvent?.Invoke(new HealthChangedEventArgs(currentHp, _health));

            if (health <= 0)
            {
                _health = 0;
                _isDestroyed = true;
                return;
            }
        }

        public void SetIsDestroyed(bool state)
        {
            _isDestroyed = state;
        }

        public bool GetIsDestroyed()
        {
            return _isDestroyed;
        }

        public bool CheckDied()
        {
            if (this._isDestroyed)
            {
                Log($"The unit {this._name} is died!");
                return true;
            }
            return false;
        }

        protected event healthChangedDelegate healthChangedEvent;
    }
}