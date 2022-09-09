namespace WarcraftGameCore
{ 
    public abstract class Moveble : Unit
    {
        private double _speed;

        protected Moveble(Logger logger, double speed, string name, double health, 
            int cost, int level, double maxHp) 
            : base(logger, name, health, cost, level, maxHp)
        {
            _speed = speed;
        }

        public void Move()
        {
            if (CheckDied())
            {
                return;
            }

            Log($"{GetName()} move!Speed: {_speed}");
        }
    }
}