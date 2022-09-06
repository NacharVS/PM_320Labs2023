namespace WarcraftGameCore
{
    public abstract class Unit
    {
        protected double _health;
        protected int _cost;
        protected String _name;
        protected int _level;
        protected bool _isDestroyed;

        protected Unit(string name, double health, int cost, int level)
        {
            _name = name;
            _health = health;
            _cost = cost;
            _level = level;
        }

        public string GetName()
        {
            return _name;
        }

        public double GetHealth()
        {
            return _health;
        }

        public virtual void SetHealth(double health)
        {
            if (health <= 0)
            {
                _health = 0;
                _isDestroyed = true;
                return;
            }

            _health = health;
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
                Console.WriteLine($"The unit {this._name} is died!");
                return true;
            }
            return false;
        }
    }
}