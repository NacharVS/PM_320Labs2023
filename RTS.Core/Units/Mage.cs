using RTS.Core.BaseEntities;
using RTS.Core.EventArgs;
using Range = RTS.Core.BaseEntities.Ranged;

namespace RTS.Core.Units;

public class Mage : Ranged
{
    private static readonly Dictionary<string, int> SpellsCost = new()
    {
        {nameof(FireBall), 10},        
        {nameof(Blizzard), 15},
        {nameof(Heal), 90}
    };

    private static readonly Dictionary<string, int> SpellsDamage = new()
    {
        { nameof(FireBall), 30 },
        { nameof(Blizzard), 50 },
        { nameof(Heal), -10 }
    };

    public delegate void SpellAttackHandler(Mage sender, SpellArgs args);

    public event SpellAttackHandler? OnSpellAttack;

    public Mage(int health, int cost, string? name, int level, int speed, int damage, 
        int attackSpeed, int armor, int attackRange, int mana) 
        : base(health, cost, name, level, speed, damage, attackSpeed, armor, attackRange, mana)
    {
        OnSpellAttack += delegate(Mage mage, SpellArgs args)
        {
            if (mage.Mana >= args.SpellCost)
            {
                mage.Mana -= args.SpellCost;
                Attack(args.Target, args.SpellDamage);
            }
            else
            {
                Console.WriteLine("Нам нужно больше маны, милорд!");
            }
        };
    }

    public void FireBall(Unit entity)
    {
        CastSpell(entity, nameof(FireBall));
    }
    
    public void Blizzard(Unit entity)
    {
        CastSpell(entity, nameof(Blizzard));
    }
    
    public void Heal(Unit entity)
    {
        CastSpell(entity, nameof(Heal));
    }

    private void CastSpell(Unit entity, string spellName)
    {
        OnSpellAttack?.Invoke(this, new SpellArgs(
            entity, 
            SpellsCost[spellName], 
            SpellsDamage[spellName])
        );
    }
}