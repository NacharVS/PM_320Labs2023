namespace WarCraft_3_ConsoleEdition
{
    class Archer : Range 
    {
        public int arrowCount;

        public delegate void HealthChangedDelegate(string message);
        public event HealthChangedDelegate? HealthChangedEvent;

        public Archer(int arrowCount, int range, int damage, int attackSpeed,
            int armor, int speed, int health, int cost, string name, int level)
            : base(arrowCount, range, damage, attackSpeed, armor, speed, health, cost, name, level) 
        {
            this.arrowCount = arrowCount;
            HealthChangedEvent?.Invoke("Ура что то работает");
        }
    }

}
