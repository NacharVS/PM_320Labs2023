using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units
{
    public abstract class Military : Movable
    {
        private double _damage;

        private double _attackSpeed { get; set; }
    
        private double _armor { get; set; }

        public abstract void Attack(Unit unit);

        public double GetDamage()
        {
            return _damage;
        }

        public double GetAttackSpeed()
        {
            return _attackSpeed;
        }

        public void SetAttackSpeed(double newAttackSpeed)
        {
            _attackSpeed = newAttackSpeed;
        }
    }
}
