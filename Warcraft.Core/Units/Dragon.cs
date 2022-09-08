using Warcraft.Core.BaseEntities;
using Warcraft.Core.EventArgs;

namespace Warcraft.Core.Units
{
    public class Dragon : Ranged
    {
        private static readonly Dictionary<string, int> SpellsCost = new()
        {
            {nameof(FireBreath), 150}
        };

        private static readonly Dictionary<string, int> SpellsDamage = new()
        {
            {nameof(FireBreath), 200}
        };

        private delegate void SpellAttackHandler(Dragon sender, SpellArgs args);

        private event SpellAttackHandler? OnSpellAttack;

        public void FireBreath(Unit enemy)
        {
            string spellName = nameof(FireBreath);
            
            OnSpellAttack?.Invoke(this, new SpellArgs(
                enemy, 
                SpellsDamage[spellName],
                SpellsCost[spellName],
                spellName)
            );
        }

        public override void Move() { }

        public Dragon(int health, int cost, string? name, int level, int speed, int damage,
            int attackSpeed, int armor, int range, int mana) 
            : base(health, cost, name, level, speed, damage, attackSpeed, armor, range, mana)
        {
            OnSpellAttack += delegate(Dragon sender, SpellArgs args)
            {
                if (sender.Mana >= args.SpellCost)
                {
                    sender.Mana -= args.SpellCost;
                    Attack(args.Target, args.SpellDamage);
                }
                else
                    Console.WriteLine($"Не хватает маны на {args.SpellName}");
            };
        }
    }
}
