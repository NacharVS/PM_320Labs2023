namespace WarCraft_3_ConsoleEdition
{
    public class Footman : Military
    {
        public bool IsBerserk { get; set; }
        public int StunTime { get; private set; } = 5;

        public delegate void HealthChangedDelegate();

        public Footman(int damage, int attackSpeed, int armor, int speed, int health,
            int cost, string name, int level) : base(damage, attackSpeed, armor, speed, 
                health, cost, name, level) { }

        private void Berserker()
        {
            if (!IsBerserk)
            {
                Damage *= 2;
            }

            IsBerserk = true;
        }

        public void Stun(Movable movable)
        {
            movable.TimeWithoutAttack += StunTime;
        }

        private void BerserkReport()
        {
            Console.WriteLine($"{Name} used Berserker");
        }
                                                                                    
        public event HealthChangedDelegate HealthChangedEvent;

        HealthChangedEvent += Berserker();
        HealthChangedEvent += BerserkReport();
    }
}
