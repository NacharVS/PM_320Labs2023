using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units
{
    public class Footman : Military
    {

        public void Rage() 
        {
            this.SetAttackSpeed(this.GetAttackSpeed() * 2);
        }

        public void Stun() { }

        public override void Attack(Unit unit)
        {
            //Перенести в main
            if(!unit.GetStateOfLife())
            {
                throw new Exception("Enemy is dead");
            }
            //Перенести в main

            unit.SetHealth(unit.GetHealth() - this.GetDamage());

            if(unit.GetHealth() < 0)
            {
                unit.SetHealth(0);   
            }
            
            unit.SetStateOfLife(false);
        }

        public override void Move()
        {
            
        }
    }
}
