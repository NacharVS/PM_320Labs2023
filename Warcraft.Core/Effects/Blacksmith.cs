using Warcraft.Core.BaseEntities;

namespace Warcraft.Core.Effects;

public class Blacksmith
{
    public IEnumerable<Unit> Units { get; private protected set; }

    public Blacksmith(IEnumerable<Unit> units)
    {
        Units = units;
    }

    public void UpgradeWeapon(int damage)
    {
        foreach (var unit in Units.Where(x => x.GetType() == typeof(Military)))
        {
            ((Military)unit).UpgradeWeapon(damage);
        }
    }
    
    
    public void UpgradeWArmor(int armor)
    {
        foreach (var unit in Units.Where(x => x.GetType() == typeof(Military)))
        {
            ((Military)unit).UpgradeArmor(armor);
        }
    }
}