namespace WarcraftCore;

public class Blacksmith
{
    private readonly List<Unit> unitsList;
    private ILogger logger;
    
    private const int UPGRADE_ARMOR_COUNT = 2;
    private const int UPGRADE_WEAPON_COUNT = 4;
    private const int UPGRADE_BOW_COUNT = 10;

    private int upgradeSpeed;

    public Blacksmith(List<Unit> units, ILogger logger, int upgradeSpeed)
    {
        this.unitsList = units;
        this.logger = logger;
        this.upgradeSpeed = upgradeSpeed;
    }

    public void UpgradeArmor(int currentTick)
    {
        foreach (Millitary millitary in unitsList.Select(x => x as Millitary))
        {
            if (millitary is null || CanUpgrade(currentTick))
            {
                return;
            }
            
            millitary.UpgradeArmor(UPGRADE_ARMOR_COUNT);
        }
        logger.Log("Blacksmith улучшил броню всех персонажев");
    }

    public void UpgradeWeapon(int currentTick)
    {
        foreach (Millitary millitary in unitsList.Select(x => x as Millitary))
        {
            if (millitary is null || CanUpgrade(currentTick))
            {
                return;
            }
            
            millitary.UpgradeWeapon(UPGRADE_WEAPON_COUNT);
        }
        logger.Log("Blacksmith улучшил оружие всех персонажев");
    }

    public void UpgradeBow(int currentTick)
    {
        foreach (Archer archer in unitsList.Select(x => x as Archer))
        {
            if (archer is null || CanUpgrade(currentTick))
            {
                return;
            }
            
            archer.UpgradeBow(UPGRADE_BOW_COUNT);
        }
        logger.Log("Blacksmith улучшил лук у всех лучников");
    }

    public bool CanUpgrade(int currentTick)
    {
        return currentTick == upgradeSpeed;
    }
    
}