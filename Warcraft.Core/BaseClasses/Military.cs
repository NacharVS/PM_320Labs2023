namespace Warcraft.Core.BaseClasses;

public abstract class Military : Movable
{
    // временной промежуток выделенный на атаку
    private const int AttackTimeRange = 1000;
    public int Damage { get; protected set; }
    public int AttackSpeed { get; protected set; }
    public int Armor { get; protected set; }

    protected Dictionary<string, Action<Unit>> Spells { get; set; }
    public string[] SpellNames => Spells.Keys.ToArray();

    protected Military(IEventLogger logger, int health, int cost, string name,
        int level, int speed,
        int attackSpeed, int damage) : base(logger, health, cost, name, level,
        speed)
    {
        AttackSpeed = attackSpeed;
        Damage = damage;
        Spells = new Dictionary<string, Action<Unit>>();
    }

    public void CastSpell(string spellName, Unit target)
    {
        Spells[spellName].Invoke(target);
    }

    internal override void Hit(int damage)
    {
        damage = Math.Min(damage, damage - Armor);
        base.Hit(damage);
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