namespace WarcraftGameCore
{
    public class Peasant : Moveble
    {
        public Peasant(Logger logger, string name) : base(logger, 20, name, 2000, 1500,2, 2500) { }

        public void Mining()
        {
            if (this.CheckDied())
            {
                return;
            }

            Log($"{this._name} is mining");
        }

        public void Choping()
        {
            if (this.CheckDied())
            {
                return;
            }

            Log($"{this._name} is choping");
        }
    }
}