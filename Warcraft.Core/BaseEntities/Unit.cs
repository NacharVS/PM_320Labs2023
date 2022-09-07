using Warcraft.Core.EventArgs;

namespace Warcraft.Core.BaseEntities
{
     public abstract class Unit 
    {
        public int Health { get; private protected set; }
        public int Cost { get; private protected set; }
        public string? Name { get; private protected set; }
        public int Level { get; private protected set; }
        public bool IsDestroyed { get; private protected set; }
        public int MaxHealth { get; private protected set; }

        public delegate void HitHandler(Unit sender, HitArgs args);
        public delegate void DeathHandler(Unit sender, DeathArgs args);

        public event HitHandler? OnGetDamage;
        public event DeathHandler? OnDeath;
        
        protected Unit(int health, int cost, string? name, int level)
        {
            Health = health;
            Cost = cost;
            Name = name;
            Level = level;
            IsDestroyed = false;
            MaxHealth = health;
            
            OnGetDamage += delegate(Unit _, HitArgs args)
            {
                if (IsDestroyed)
                {
                    Console.WriteLine("Enemy is already dead");
                }

                Health -= args.Damage;

                if (Health <= 0)
                    OnDeath?.Invoke(this, new DeathArgs());
            };
            
            OnDeath += delegate
            {
                IsDestroyed = true;
                Health = 0;
                Console.WriteLine($"{Name} is eliminated");
            };
        }

        public void GetDamage(int damage)
        {
            OnGetDamage?.Invoke(this, new HitArgs(damage, Health));
        }

        private protected void RaiseOnHitEvent(Unit sender, HitArgs args)
        {
            OnGetDamage?.Invoke(sender, args);
        }

        private protected void RaiseOnDeathEvent(Unit sender, DeathArgs args)
        {
            OnDeath?.Invoke(sender, args);
        }
    }
}
