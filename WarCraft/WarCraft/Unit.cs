using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarCraft
{
    class Unit
    {
        public string Name { get; set; }

        private int _health;

        public delegate void HealthChangedDelegate(int healthValue, int maxHealthValue);
        public int Health
        {
            get { return _health; }
            set 
            {
                _health = value; 
                HealthChangedEvent?.Invoke(_health, MaxHealth);
            }
        }
        public int MaxHealth { get; set; }
        public int Cost { get; set; }
        public int Lvl { get; set; }
        public bool IsDestroyed { get; set; }

        public Unit(string name, int health, int cost)
        {
            this.Name = name;
            this.Health = health;
            this.MaxHealth = health;
            this.Cost = cost;
            this.Lvl = 1;
            this.IsDestroyed = false;
        }

        public bool Death()
        {
            if (Health <= 0)
            {
                Health = 0;
                IsDestroyed = true;
                HealthChangedEvent?.Invoke(_health, MaxHealth);
                return true;
            }
            return false;
        }

        public void Hit(int damage)
        {
            Health -= damage;
        }

        public event HealthChangedDelegate HealthChangedEvent;
    }
}
