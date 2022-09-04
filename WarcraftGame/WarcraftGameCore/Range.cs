namespace WarcraftGameCore
{
    public abstract class Range : Military
    {
        private int _range;
        protected int _mana;

        protected Range(int range, int mana, double damage, 
            int attackSpeed, double armor, double speed, 
            string name, double health, int cost, int level) 
            : base (damage,attackSpeed, armor, speed,
            name, health, cost, level)
        {
            _range = range;
            _mana = mana;
        }
    }
}
