public class Archer : Range
{
    public int arrowCount;
    public Archer(int archHP, int archMaxHP, int archCost, string archName, int archDamage, int archAttackSpeed, int archArmor, int archArrowCount)
    {
        health = archHP;
        maxHP = archMaxHP;
        cost = archCost;
        name = archName;
        lvl = 1;
        damage = archDamage;
        attackSpeed = archAttackSpeed;
        armor = archArmor;
        arrowCount = archArrowCount;
        speed = 7;
            
    }
}

