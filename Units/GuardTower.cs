using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units
{
    public class GuardTower : Unit
    {
        private double _range;
        private double _damage;
        private int _attackSpeed;

        public GuardTower(double health, double range, double damage, int attackSpeed) : base(health)
        {
            _range = range;
            _damage = damage;
            _attackSpeed = attackSpeed;
        }

        public void Attack(Unit unit)
        {
            if (!unit.GetStateOfLife())
            {
                throw new Exception("Enemy is destroyed!");
            }

            unit.SetHealth(unit.GetHealth() - _damage);

            if (unit.GetHealth() <= 0)
            {
                unit.SetStateOfLife(false);
            }
        }
    }
}
