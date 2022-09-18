using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units.BaseUnits
{
    public abstract class Military : Movable
    {
        private double _damage;
        private double _maxDamage;
        private int _attackSpeed;
        private int _maxAttackSpeed;
        private int _stunCounter = 0;
        private double _armor = 0;
        private double _maxArmor = 0;

        public delegate void AttackDelegate(Unit unit, double totalDamage);
        public event AttackDelegate AttackEvent;
        private double _Armor
        {
            get { return _armor; }
            set
            {
                if (value < 0)
                {
                    _armor = 0;
                }
                else
                {
                    _armor = value;
                }
            }
        }


        public Military(double health, double armor, int attackSpeed, double damage, string name)
            : base(health, name)
        {
            _armor = armor;
            _attackSpeed = attackSpeed;
            _maxAttackSpeed = attackSpeed;
            _damage = damage;
            _maxDamage = damage;
            AttackEvent += ResultAttack;
        }

        public override void Attack(Unit unit)
        {
            if (_attackSpeed == 0)
            {
                _stunCounter++;
                return;
            }

            if (_stunCounter > 1)
            {
                _stunCounter = 0;
                _attackSpeed = _maxAttackSpeed;
            }

            if (unit is not Military)
            {
                double damage = GetDamage();
                AttackEvent(unit, damage);

            }
            else
            {
                int damageTakenByArmor = (int)(GetDamage() * ((Military)unit).GetArmor() / 100);
                double totalDamage = GetDamage() - damageTakenByArmor;

                ((Military)unit).SetArmor(((Military)unit).GetArmor() - damageTakenByArmor);
                AttackEvent(unit, totalDamage);
            }
        }

        private void ResultAttack(Unit unit, double totalDamage)
        {
            Console.WriteLine($"{Name} damaged {unit.Name} " +
                $"for {totalDamage}");
            unit.SetHealth(unit.GetHealth() - totalDamage);
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

        public void SetMaxDamage(double damage)
        {
            _maxDamage = damage;
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

        public double GetArmor()
        {
            return _Armor;
        }

        public void SetArmor(double armor)
        {
            _Armor = armor;
        }

        public double GetMaxArmor()
        {
            return _maxArmor;
        }

        public void SetMaxArmor(double armor)
        {
            _maxArmor = armor;
        }

        public int GetRandom()
        {
            Random rand = new Random();
            return rand.Next(1, 11);
        }
    }
}
