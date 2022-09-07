using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units
{
     public abstract class Unit 
    {
        private double _health { get; set; }
        private int _cost { get; set; }
        private string _name { get; set; }
        private int _level { get; set; }

        private bool _isDestroyed;
        private double _maxHealth { get; set; }

        public double GetHealth() 
        {
            return _health;
        }

        public void SetHealth(double health)
        {
            _health = health;
        }

        public void SetStateOfLife(bool isDestroyed)
        {
            _isDestroyed = isDestroyed;
        }

        public bool GetStateOfLife()
        {
            return _isDestroyed;
        }
    }
}
