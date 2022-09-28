using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeaponGame_Core.Interfaces;

namespace WeaponGame_Core.Weapons
{
    public class Ak47: IWeapon, ITripleShot
    {
        int damage = 30;
        int endurance = 90;
        int cartidges = 120;
        public Ak47()
        {

        }
        public void Repair()
        {
            if (endurance + 10 <= 100)
            {
                endurance += 10;
                Log($"{this.GetType().Name} fixed, it's endurance: {endurance}");
            }
            else
            {
                endurance = 100;
                Log($"{this.GetType().Name} cannot be repaired, has maximum endurance: {endurance}");
            }
        }
        public void Upgrade()
        {
            damage += 5;
            Log($"{this.GetType().Name} upgraded, it's damage: {damage}");
        }   
        public void Reload()
        {
            Log($"{this.GetType().Name} reloaded");
        }
        public void TripleShot()
        {
            if(cartidges >= 3)
            {
                cartidges-=3;
                Log($"{this.GetType().Name} made triple shot, cartidges count: {cartidges}");
            }
            else
            {
                Log($"{this.GetType().Name} couldn't made triple shot, done: {cartidges} shot");
                cartidges = 0;
            }
            
        }
        public void Log(string message)
        {
            Console.WriteLine(message);
        }

       
    }
}
