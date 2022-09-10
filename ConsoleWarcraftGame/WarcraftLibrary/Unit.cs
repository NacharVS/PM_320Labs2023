using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarcraftLibrary
{
    public class Unit
    {
        public string Name;
        private int _health;
        public int Health
        {
            get { return _health; }
            set
            {
                HealthChangedEvent?.Invoke(Name, _health, value);
                _health = value;
            }
        }
        public int Cost;
        public int Lvl;
        public bool IsDestroyed;
        public int Damage;
        public delegate void DestroyingDelegate(string message);
        public delegate void HealthChangedDelegate(string name, int beforeHealthValue, int healthValue);

        public Unit(string name, int health, int cost, int lvl, bool isDestroyed, int damage)
        {
            this.Name = name;
            this._health = health;
            this.Cost = cost;
            this.Lvl = lvl;
            this.IsDestroyed = isDestroyed;
            this.Damage = damage;
        }

        public virtual string Attack(Unit unit, Blacksmith blacksmith)
        {
            return " ";
        }

        public void Checking()
        {
            if (Health <= 0)
            {
                IsDestroyed = true;
                DestroyingEvent?.Invoke($"{Name} погиб");
            }
        }

        public event HealthChangedDelegate HealthChangedEvent;
        public event DestroyingDelegate DestroyingEvent;
    }
}
