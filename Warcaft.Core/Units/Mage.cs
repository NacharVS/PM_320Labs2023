using Warcaft.Core.BaseEntities;

namespace Warcaft.Core.Units
{
    public class Mage : Ranged
    {
        public Mage(int health, int cost, string? name, int level, int speed, int damage,
            int attackSpeed, int armor, int range, int mana)
            : base(health, cost, name, level, speed, damage, attackSpeed, armor, range, mana)
        {
        }
        
        public void Fireball() { }

        public void Blizzard() { }

        public void Heal() { }

        public override void Attack(Unit unit)
        {

        }

        public override void Move() { }
    }
}
