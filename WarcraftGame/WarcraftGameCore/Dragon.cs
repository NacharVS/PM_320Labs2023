namespace WarcraftGameCore
{
    public class Dragon : Range
    {

        public Dragon(string name) : base (3, 300, 1000, 4, 600, 15, name, 2200, 1300, 3) {}

        public void FireBreuth(Unit unit)
        {
            if (this._mana >= 200)
            {
                this.Attack(unit, 4000);
            }
            else
            {
                Console.WriteLine("Not have mana!");
            }
        }
    }
}
