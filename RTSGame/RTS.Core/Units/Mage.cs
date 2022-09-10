using RTS.Core.BaseEntities;
using RTS.Core.Effects;
using RTS.Core.EventArgs;
using RTS.Core.Logger;
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
        int attackSpeed, int armor, int attackRange, int mana, ILogger logger) 
        : base(health, cost, name, level, speed, damage, attackSpeed, armor, attackRange, mana, logger)
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
                Logger.Log(LogMessageType.Info, "Нам нужно больше маны, милорд!");
                Logger.Log(LogMessageType.Info, "Использую обычную атаку..");
                Attack(args.Target, Damage);
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

    public void FireFloor(Unit entity)
    {
        if (Mana > 170)
        {
            Thread.Sleep(1000);
            ThreadPool.QueueUserWorkItem(
                        new TemporaryEffect(entity, TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(0.3), delegate(Unit unit)
                            {
                                unit.GetDamage(30);
                            })
                            .Append);
            Mana -= 170;
        }
        else
        {
            Attack(entity);
        }
    }
    

    public IEnumerable<Action<Unit>> GetSpellsList()
    {
        return new List<Action<Unit>>()
        {
            FireFloor
        };
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