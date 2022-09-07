using System;

namespace WarCraft_3_ConsoleEdition
{
    public class Footman : Military
    {
        public bool IsBerserk { get; set; }
        public int StunTime { get; private set; } = 5;

        public delegate void HealthChangedDelegate();
        public delegate void StunDelegate(Movable unit);

        public Footman(int damage, int attackSpeed, int armor, int speed, int health,
            int cost, string name, int level) : base(damage, attackSpeed, armor, speed, 
                health, cost, name, level) { }

        public void Berserker()
        {
            if (!IsBerserk)
            {
                Damage *= 2;
                HealthChangedEvent?.Invoke();
                IsBerserk = true;
            }
        }

        public void Stun(Movable unit)
        {
            unit.TimeWithoutAttack += StunTime;
            StunEvent?.Invoke(unit);
        }

        public void BerserkReport()
        {
            Console.WriteLine($"{Name} used Berserker");
        }

        public void StunReport(Movable unit)
        {
            Console.WriteLine($"{Name} stunned " +
                            $"{unit.Name} for {StunTime} second");
        }
                                                                                    
        public event HealthChangedDelegate HealthChangedEvent;
        public event StunDelegate StunEvent;
    }
}
