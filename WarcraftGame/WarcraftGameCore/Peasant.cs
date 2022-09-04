namespace WarcraftGameCore
{
    public class Peasant : Moveble
    {
        public Peasant(string name) : base(20, name, 2000, 1500,2) { }

        public void Mining()
        {
            Console.WriteLine($"{this._name} is mining");
        }

        public void Choping()
        {
            Console.WriteLine($"{this._name} is choping");
        }
    }
}
