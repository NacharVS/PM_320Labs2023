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
        private double _maxDamage;
        private int _attackSpeed;
        private int _maxAttackSpeed;
        private double _armor;
        private int _stunCounter = 0;
        

        public Military(double health, double armor, int attackSpeed, double damage) 
            : base(health)
        {
            this._armor = armor;
            this._attackSpeed = attackSpeed;
            this._maxAttackSpeed = attackSpeed;
            this._damage = damage;
            this._maxDamage = damage;
        }
        public virtual void Attack(Unit unit)
        {
            if(_attackSpeed == 0)
            {
                _stunCounter++;
                return;
            }

            if(_stunCounter > 1)
            {
                _stunCounter = 0;
                _attackSpeed = _maxAttackSpeed;
            }

            unit.SetHealth(unit.GetHealth() - this.GetDamage());

            if (unit.GetHealth() <= 0)
            {
                unit.SetStateOfLife(false);
                throw new Exception("Enemy is destroyed!");
            }
        }

        public double GetDamage()
        {
            return _damage;
        }

        public void SetDamage(double damage)
        {
            _damage = damage;
        }

        public double GetMaxDamage()
        {
            return _maxDamage;
        }

        public int GetAttackSpeed()
        {
            return _attackSpeed;
        }

        public int GetMaxAttackSpeed()
        {
            return _maxAttackSpeed;
        }

        public int SetAttackSpeed(int newAttackSpeed)
        {
            return _attackSpeed = newAttackSpeed;
        }

        public int GetRandom()
        {
            Random rand = new Random();
            return rand.Next(1, 11);
        }
    }
}
