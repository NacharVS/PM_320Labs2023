namespace WarcraftGameCore
{
    public abstract class Moveble : Unit
    {
        private double _speed;

        protected Moveble(double speed, string name, double health, int cost, int level) 
            : base(name, health, cost, level)
        {
            _speed = speed;
        }

        public void Move()
        {
            if (this.CheckDied())
            {
                return;
            }

            Console.WriteLine($"{this._name} move!Speed: {_speed}");
        }
    }
}