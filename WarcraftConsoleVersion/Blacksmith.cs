public class Blacksmith
{
    public int healtPoint;
    public string name;
    public int cost;

    public Blacksmith(int healtPoint, string name, int cost)
    {
        this.healtPoint = healtPoint;
        this.name = name;
        this.cost = cost;
    }

    public void UpgradeWeapon(Military client)
    {
        client.damage = client.damage + 1;
    }
    public void UpgradeArmor(Military client)
    {
        client.armor = client.armor + 1;
    }
    public void UpgradeBow(Archer client)
    {
        client.damage = client.damage + 1;
    }
}