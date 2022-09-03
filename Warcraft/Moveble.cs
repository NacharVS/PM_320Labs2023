namespace Warcraft
{
    class Moveble : Unit
    {
        int speed;

        public Moveble(int health, int cost, string name, int lvl, int speed)
            : base(health, cost, name, lvl)
        {
            this.speed = speed;
        }



        virtual public void Move()
        {

        }
    }
}
