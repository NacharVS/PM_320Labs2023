using Warcraft.Core.BaseEntities;
using Warcraft.Core.EventArgs;

namespace Warcraft.Core.Units
{
    public class Mage : Ranged
    {
        private static readonly Dictionary<string, int> SpellsCost = new()
        {
            {nameof(Fireball), 20},        
            {nameof(Blizzard), 35},
            {nameof(Heal), 80}
        };

        private static readonly Dictionary<string, int> SpellsDamage = new()
        {
            {nameof(Fireball), 30},
            {nameof(Blizzard), 50},
            {nameof(Heal), -30}
        };
        
        public delegate void SpellAttackHandler(Mage sender, SpellArgs args);

        public event SpellAttackHandler? OnSpellAttack;
        
        public Mage(int health, int cost, string? name, int level, int speed, int damage,
            int attackSpeed, int armor, int range, int mana)
            : base(health, cost, name, level, speed, damage, attackSpeed, armor, range, mana)
        {
            OnSpellAttack += delegate(Mage sender, SpellArgs args)
            {
                if (sender.Mana >= args.SpellCost)
                {
                    sender.Mana -= args.SpellCost;
                    Attack(args.Target, args.SpellDamage);
                }
                else
                {
                    Console.WriteLine("Нужно больше маны");
                }
            };
        }
        
        public void Fireball(Unit enemy) { CastSpell(enemy, nameof(Fireball)); }

        public void Blizzard(Unit enemy) { CastSpell(enemy, nameof(Blizzard));}

        public void Heal(Unit enemy) { CastSpell(enemy, nameof(Heal));}

        private void CastSpell(Unit enemy, string spellName)
        {
            OnSpellAttack?.Invoke(this, new SpellArgs(
            enemy,
            SpellsDamage[spellName],
            SpellsCost[spellName])
            );
        }

        public override void Move() { }
    }
}
