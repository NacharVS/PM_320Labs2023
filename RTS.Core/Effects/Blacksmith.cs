using RTS.Core.BaseEntities;
using RTS.Core.Units;

namespace RTS.Core.Effects;

public class Blacksmith
{
    public IEnumerable<Unit> Units { get; private protected set; }

    public Blacksmith(IEnumerable<Unit> units)
    {
        Units = units;
    }

    public void UpgradeArrow(int damage)
    {
        foreach (var military in Units.Where(x => x.GetType() == typeof(Archer)))
        {
            ((Military)military).UpgradeWeapon(damage);
        }
    }

    public void UpgradeWeapon(int damage)
    {
        foreach (var military in Units.Where(x => x.GetType() == typeof(Military)))
        {
            ((Military)military).UpgradeWeapon(damage);
        }
    }

    public void UpgradeArmory(int armor)
    {
        foreach (var military in Units.Where(x => x.GetType() == typeof(Military)))
        {
            ((Military)military).UpgradeArmor(armor);
        }
    }
}