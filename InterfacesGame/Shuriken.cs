using System;
namespace InterfacesGame
{
    public class Shuriken : IThrowable
    {

       
        public int ThrowDamage { get; set; }
        private int _durability;
        private int _maxDurability;

        public Shuriken()
        {
        }
     
        public void Throw()
        {
            Console.WriteLine($"Shuriken inflicted of {ThrowDamage} throwable damage");
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
                Console.WriteLine("Shuriken is broken");
            }
            else
            {
                Console.WriteLine($"Shuriken inflicted of {ThrowDamage} throw damage");
                Durability -= 2;
            }
        }


        public void DealDamage()
        {
            Console.WriteLine("Deal damage by Shuriken");
        }

        public void Reload()
        {
            Console.WriteLine("Knife is reloaded");
        }

        public void Upgrade()
        {
            ThrowDamage += 5;
            Console.WriteLine($"new throw damage {ThrowDamage}");
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Shuriken durability {Durability}");
        }

        public void Repair()
        {
            Durability += 4;
            Console.WriteLine("Shuriken has repaired by 4");

            if (Durability > _maxDurability)
            {
                Durability = _maxDurability;
            }
        }
    }
}
