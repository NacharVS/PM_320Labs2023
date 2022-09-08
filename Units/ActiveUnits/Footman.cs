using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Units.BaseUnits;

namespace Units.ActiveUnits
{
    public class Footman : Military
    {
        public delegate void OnStunDelegate(Unit unit);
        public event OnStunDelegate OnStunEvent;

        public Footman(double health, double armor,
            int attackSpeed, double damage, string name)
            : base(health, armor, attackSpeed, damage, name)
        {
            OnStunEvent += CharacterToStun;
        }

        private void Berserker()
        {
            this.SetAttackSpeed(GetAttackSpeed() * 2);
            this.SetDamage(GetDamage() * 1.2);
        }

        private void Stun(Military unit)
        {
            unit.SetAttackSpeed(0);
        }

        public override void Move()
        {
            Console.WriteLine("Footman is moving");
        }

        public override void Attack(Unit unit)
        {
            if (GetHealth() / GetMaxHealth() < 1 / 3)
            {
                Berserker();
            }

            if (GetRandom() == 1)
            {
                if (unit is Military)
                {
                    Stun((Military)unit);
                }
                OnStunEvent?.Invoke(unit);
            }
            else
            {
                SetAttackSpeed(GetMaxAttackSpeed());
                SetDamage(GetMaxDamage());
            }

            base.Attack(unit);
        }
        private void CharacterToStun(Unit unit)
        {
            Console.WriteLine($"{this.Name} stunned {unit.Name}!");
        }
    }
}
