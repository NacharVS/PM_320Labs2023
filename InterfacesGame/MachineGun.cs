using System;
namespace InterfacesGame
{
    public class MachineGun : IHaveAutoMade
    {
        public MachineGun(int durability)
        {
            _durability = durability;
            _maxDurability = durability;
            _damage = 8;
        }

        public void AutoModeShoot()
        {
            if (Durability < 6)
            {
                Console.WriteLine("MachineGun is broken");
            }
            else
            {
                Console.WriteLine($"MachineGun shooting with {Damage * 3}");
                Durability -= 6;
            }
        }

        private int _damage;
        private int _durability;
        private int _maxDurability;

        public int Damage
        {
            get { return _damage; }
            set { _damage = value; }
        }

        public int Durability
        {
            get { return _durability; }
            set { _durability = value; }
        }

        public int Distance { get; set; }

        public void SingleShoot()
        {
            if (Durability < 2)
            {
                Console.WriteLine("MachineGun is broken");
            }
            else
            {
                Console.WriteLine($"MachineGun shooting with {Damage}");
                Durability -= 2;
            }
        }

        public void Reload()
        {
            Console.WriteLine("MachineGun is reloaded");
        }

        public void Repair()
        {
            Durability += 4;
            Console.WriteLine("MachineGun has repaired by 4");

            if (Durability > _maxDurability)
            {
                Durability = _maxDurability;
            }
        }

        public void UpgradeDamage()
        {
            Damage += 6;
            Console.WriteLine($"new damage {Damage}");
        }

        public void ShowInfo()
        {
            Console.WriteLine($"MachineGun durability {Durability}");
        }


        public void Upgrade()
        {
            Damage += 5;
            Console.WriteLine($"new damage {Damage}");
        }

        public void DealDamage()
        {
            Console.WriteLine("Deal damage by MachineGun");
        }
    }
}