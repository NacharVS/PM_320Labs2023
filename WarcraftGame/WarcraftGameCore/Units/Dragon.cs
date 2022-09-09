namespace WarcraftGameCore
{
    public class Dragon : Range
    {
        private int _fireBreuthMana = 200;
        private double _fireBreuthDamage = 1800;

        public Dragon(Logger logger, string name) : 
        base(logger, 3, 300, 1000, 4, 600, 15, name, 2200, 1300, 3, 2500) { }

        public void FireBreuth(Unit unit)
        {
            if (GetMana() >= _fireBreuthMana)
            {
                this.Attack(unit, _fireBreuthDamage);
                SetMana(GetMana() - _fireBreuthMana);
            }
            else
            {
                Log("Not have mana!");
            }
        }
    }
}