using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Units.BaseUnits;

namespace Units.ActiveUnits
{
    public class GuardTower : Unit
    {
        private double _range;
        private double _damage;
        private int _attackSpeed;

        public delegate void AttackDelegate(Unit unit, double totalDamage);
        public event AttackDelegate AttackEvent;

        public GuardTower(double health, double range,
            double damage, int attackSpeed, string name)
            : base(name, health)
        {
            _range = range;
            _damage = damage;
            _attackSpeed = attackSpeed;
            AttackEvent += ResultAttack;
        }

        public override void Attack(Unit unit)
        {
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
    }
}
