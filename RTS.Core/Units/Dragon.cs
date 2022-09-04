﻿using RTS.Core.BaseEntities;
using RTS.Core.EventArgs;
using Range = RTS.Core.BaseEntities.Ranged;

namespace RTS.Core.Units;

public class Dragon : Ranged
{
    private static readonly Dictionary<string, int> SpellsCost = new()
    {
        {nameof(FireBreath), 100}
    };

    private static readonly Dictionary<string, int> SpellsDamage = new()
    {
        { nameof(FireBreath), 300 }
    };
    
    private delegate void SpellAttackHandler(Dragon sender, SpellArgs args);

    private event SpellAttackHandler? OnSpellAttack;
    
    public Dragon(int health, int cost, string? name, int level, int speed, int damage, 
        int attackSpeed, int armor, int attackRange, int mana) 
        : base(health, cost, name, level, speed, damage, attackSpeed, armor, attackRange, mana)
    {
        OnSpellAttack += delegate(Dragon dragon, SpellArgs args)
        {
            if (dragon.Mana >= args.SpellCost)
            {
                dragon.Mana -= args.SpellCost;
                Attack(args.Target, args.SpellDamage);
            }
            else
            {
                Console.WriteLine("Дракон исдох");
            }
        };
    }

    public void FireBreath(Unit entity)
    {
        var spellName = nameof(FireBreath);

        OnSpellAttack?.Invoke(this, new SpellArgs(
            entity, 
            SpellsCost[spellName], 
            SpellsDamage[spellName])
        );
    }
}