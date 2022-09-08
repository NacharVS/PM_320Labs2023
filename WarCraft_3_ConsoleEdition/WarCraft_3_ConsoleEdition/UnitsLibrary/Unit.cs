namespace WarCraft_3_ConsoleEdition
{
    public class Unit
    {
        private int _health;
        private int _timeBleeding;
        private int _bleedingDamage = 2;
        public int Cost { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int TimeWithoutAttack { get; set; }
        Random rnd = new Random();

        public delegate void HealthChangedDelegate(int value, Unit unit);

        public Unit(int health, int cost, string name, int level)
        {
            this.Health = health;
            this.Cost = cost;
            this.Name = name;
            this.Level = level;
        }
        public int Health
        {
            get { return _health; }
            set
            {
                HealthChangedEvent?.Invoke(value - _health, this);
                _health = value;

                Bleeding(_bleedingDamage);
            }
        }

        private void Bleeding(int value)
        {
            int chance = rnd.Next(0, 5);

            if (_timeBleeding > 0)
            {
                Console.WriteLine($"{Name} is bleeding! " +
                    $"He takes {value} damage.");
                _health -= 2;
                _timeBleeding--;
                return;
            }

            if (chance == 0)
            {
                _timeBleeding = 5;
            }
        }

        public event HealthChangedDelegate HealthChangedEvent;
    }
}
