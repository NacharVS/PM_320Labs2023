using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Units.ActiveUnits;

namespace Units.BaseUnits
{
    public abstract class Unit
    {
        private double _health;
        public double Health
        {
            get { return _health; }
            set
            {
                {
                    if (value < 0)
                    {
                        OnDeathEvent?.Invoke(this);
                    }
                    else
                    {
                        _health = value;
                        HealthChangeEvent?.Invoke(this);
                    }
                }
            }
        }
        public string Name;
        private double _cost;
        private int _lvl;
        private bool _isAlive;
        private double _maxhealth;

        public delegate void HealthChangeDelegate(Unit unit);
        public event HealthChangeDelegate HealthChangeEvent;

        public delegate void OnDeathDelegate(Unit unit);
        public event OnDeathDelegate OnDeathEvent;

        public Unit(string name, double health)
        {
            SetStateOfLife(true);
            _health = health;
            SetMaxHealth(health);
            Name = name;
            HealthChangeEvent += GetHealthChange;
            OnDeathEvent += CharacterToDie;

        }

        public double GetHealth()
        {
            return _health;
        }

        public double SetHealth(double newHealth)
        {
            return Health = newHealth;
        }

        public bool GetStateOfLife()
        {
            return _isAlive;
        }

        public bool SetStateOfLife(bool newState)
        {
            return _isAlive = newState;
        }

        public double SetMaxHealth(double health)
        {
            return _maxhealth = health;
        }

        public double GetMaxHealth()
        {
            return _maxhealth;
        }
        public void GetHealthChange(Unit unit)
        {
            Console.WriteLine($"{unit.Name}'s health is {unit.GetHealth()}");
        }

        private void CharacterToDie(Unit unit)
        {
            SetStateOfLife(false);
            Console.WriteLine($"{unit.Name} is destroyed!");
        }
        public virtual void Attack(Unit unit)
        {
            if(this is not Military || this is not GuardTower)
            {
                Console.WriteLine($"{this.Name} can't attack!");
            }
        }
    }
}
