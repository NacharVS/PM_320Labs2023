﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units
{
    public abstract class Unit
    {
        private double _health;
        public string Name;
        private double _cost;
        private int _lvl;
        private bool _isAlive;
        private double _maxhealth;


        public Unit(string name, double health)
        {
            this.SetStateOfLife(true);
            this.SetHealth(health);
            this.SetMaxHealth(health);
            this.Name = name;
        }

        public double GetHealth()
        {
            return _health;
        }

        public double SetHealth(double newHealth)
        {
            return _health = newHealth;
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
    }
}
