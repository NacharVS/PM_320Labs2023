using System;
namespace InterfacesGame
{
    public class Knife : IThrowable, IMeleeWeapon
    {
        private int _meleeDamage = 4;
        public int ThrowDamage => 4;
        private int _durability;
        private int _maxDurability;

        public Knife(int durability)
        {
            _durability = durability;
            _maxDurability = durability;
        }

        public int Damage { get; set; }

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
                Console.WriteLine("Knife is broken");
            }
            else
            {
                Console.WriteLine($"Knife inflicted of {MeleeDamage} mlee damage");
                Durability -= 2;
            }
        }

        public void Throw()
        {
            Console.WriteLine("Knife was thrown");
        }

        public void DealDamage()
        {
            Console.WriteLine("Deal damage by knife");
        }

        public void Reload()
        {
            Console.WriteLine("Knife is reloaded");
        }

        public void Upgrade()
        {
            MeleeDamage += 5;
            Console.WriteLine($"new mlee damage {MeleeDamage}");
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Knife durability {Durability}");
        }

        public void Repair()
        {
            Durability += 4;
            Console.WriteLine("Knife has repaired by 4");

            if (Durability > _maxDurability)
            {
                Durability = _maxDurability;
            }
        }
    }
}
