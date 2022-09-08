class Dragon : Range
{
    public Dragon(int health, int cost, string name, int speed, int damage,
        int attackSpeed, int armor, int mana) : base(health, cost, name, speed, damage, attackSpeed, armor, mana)
    {
        
    }
    public void FireBreach()
    {

    }

    public override void Attack(Unit unit)
    {
        base.Attack(unit);
    }
}