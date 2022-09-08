namespace WarcraftGameCore
{
    public class Peasant : Moveble
    {
        public Peasant(string name) : base(20, name, 2000, 1500,2, 2500) { }

        public void Mining()
        {
            if (this.CheckDied())
            {
                return;
            }

            Console.WriteLine($"{this._name} is mining");
        }

        public void Choping()
        {
            if (this.CheckDied())
            {
                return;
            }

            Console.WriteLine($"{this._name} is choping");
        }
    }
}