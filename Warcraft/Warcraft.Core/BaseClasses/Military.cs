using Warcraft.Core.Spells;

namespace Warcraft.Core.BaseClasses;

public abstract class Military : Movable
{
    // временной промежуток выделенный на атаку
    private const int AttackTimeRange = 1000;
    public int Damage { get; protected set; }
    public int AttackSpeed { get; protected set; }
    public int Armor { get; protected set; }
    public int Mana { get; protected set; }

    protected Dictionary<string, Spell> Spells { get; set; }
    public string[] SpellNames => Spells.Keys.ToArray();

    protected Military(IEventLogger logger, int health, int cost, string name,
        int level, int speed,
        int attackSpeed, int damage) : base(logger, health, cost, name, level,
        speed)
    {
        AttackSpeed = attackSpeed;
        Damage = damage;
        Spells = new Dictionary<string, Spell>();
    }

    public void CastSpell(string spellName, Unit target)
    {
        var spell = Spells[spellName];

        if (spell.ManaCost > Mana)
        {
            Log("Нет маны!");
            return;
        }

        if (spell is AttackingSpell && target == this)
        {
            Log("Не могу кастовать на себя");
            return;
        }
        
        spell.Cast(target);
        Mana -= spell.ManaCost;
        Log(string.Format(spell.Message, target.Name));
    }

    internal override void Hit(int damage)
    {
        var totalDamage = Math.Min(damage, damage - Armor);
        if (totalDamage != damage)
            Log($"Броня заблокировала {damage - totalDamage} урона");
        base.Hit(totalDamage);
    }

    public virtual void Attack(Unit target)
    {
        Attack(target, Damage * (AttackTimeRange / AttackSpeed));
    }

    protected void Attack(Unit target, int damage)
    {
        if (target == this)
        {
            Log("Не могу атаковать себя!");
            return;
        }

        if (IsDestroyed)
        {
            Log("Мертв и не может атаковать");
        }

        target.Hit(damage);
        Log($"Атаковал {target.Name} на {damage} урона");
    }

    public void IncreaseArmor(int value)
    {
        Armor += value;
    }
}