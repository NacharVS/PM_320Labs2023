using System;
namespace InterfacesGame
{
    public struct Sword : IMeleeWeapon
    {
        private int _meleeDamage;
        private int _durability;
        private int _maxDurability;


        public Sword(int durability)
        {
            _durability = durability;
            _maxDurability = durability;
            _meleeDamage = 7;
        }

        public int MeleeDamage
        {
            get { return _meleeDamage; }
            set { _meleeDamage = value; }
        }

        public int Durability
        {
            get { return _durability; }
            set { _durability = value; }
        }


        public void Hit()
        {
            if (Durability < 2)
            {
                Console.WriteLine("Sword is broken");
            }
            else
            {
                Console.WriteLine($"Sword inflicted of {MeleeDamage} melee damage");
                Durability -= 2;
            }
        }

        public void Reload()
        {
            Console.WriteLine("Sword is reloaded");
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Sword durability {Durability}");
        }

        public void Repair()
        {
            Durability += 4;
            Console.WriteLine("Sword has repaired by 4");

            if (Durability > _maxDurability)
            {
                Durability = _maxDurability;
            }
        }

        public void Upgrade()
        {
            MeleeDamage += 5;
            Console.WriteLine($"new damage {MeleeDamage}");
        }

        public void DealDamage()
        {
            Console.WriteLine("Deal damage by sword");
        }
    }
}
