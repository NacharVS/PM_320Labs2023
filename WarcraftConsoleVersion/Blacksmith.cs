public class Blacksmith
{
    private int healtPoint;
    private string name;
    private int cost;

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
        client.arrowCount = client.arrowCount + 5;
    }


}