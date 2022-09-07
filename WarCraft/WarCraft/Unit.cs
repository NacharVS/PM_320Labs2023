﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarCraft
{
    class Unit
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Cost { get; set; }
        public int Lvl { get; set; }
        public bool IsDestroyed { get; set; }

        public delegate void HealthChangedDelegate();
        public event HealthChangedDelegate HealthChangedEvent;

        public Unit(string name, int health, int cost, 
            int lvl, bool isDestroyed)
        {
            this.Name = name;
            this.Health = health;
            this.Cost = cost;
            this.Lvl = lvl;
            this.IsDestroyed = isDestroyed;
        }

        public bool Death()
        {
            if (Health <= 0)
            {
                Health = 0;
                IsDestroyed = true;
                HealthChangedEvent?.Invoke();
                return true;
            }
            return false;
        }

        public void Hit(int damage)
        {
            Health -= damage;
        }
    }
}
