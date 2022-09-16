using Weaponry.Interfaces;

namespace Weaponry;

public class Engineer
{
    public void Repair(IRepairable item)
    {
        item.Repair();
    }

    public void Upgrade(IUpgradable item)
    {
        item.Upgrade();
    }
}