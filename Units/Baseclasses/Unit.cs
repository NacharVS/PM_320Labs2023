// Turushkin Sergey, 320P, "Warcraft"

namespace Units.BaseClasses
{
    public abstract class Unit
    {
        private double _health = 0;
        public double health
        {
            get { return _health; }
            set
            {
                if (value < _health)
                {

                    _health = value;
                    HealthChangedEvent?.Invoke();
                }

                _health = value;
            }
        }

        public double cost;
        public string name;
        public int lvl;
        public bool isDestroyed;
        public double maxHealth;
        public Action action;

        public delegate void HealthChangedDelegate();
        public event HealthChangedDelegate HealthChangedEvent;

        public delegate void OnDiedDelegate();
        public event OnDiedDelegate OnDiedEvent;

        public Unit(double health, double cost, string name, int lvl)
        {
            this.health = health;
            maxHealth = health;
            this.cost = cost;
            this.name = name;
            this.lvl = lvl;
            isDestroyed = false;

            OnDiedEvent += Unit_OnDiedEvent;
            HealthChangedEvent += Unit_HealthChangedEvent;
        }

        private void Unit_HealthChangedEvent()
        {
            action.Unit_HealthChangedEvent(this);
        }

        private void Unit_OnDiedEvent()
        {
            action.Unit_OnDiedEvent(this);
        }

        public void IsDestroyed()
        {
            if (health <= 0) OnDiedEvent.Invoke();
            isDestroyed = true;
            health = 0;
        }
    }
}
