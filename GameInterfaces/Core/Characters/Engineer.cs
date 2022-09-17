using Core.Interfaces;

namespace Core.Characters;

public class Engineer
{
    public void RepairItem(IRepairable item)
    {
        item.Repair();
    }
    
    public void UpgradeItem(IUpgradable item)
    {
        item.Upgrade();
    }
}