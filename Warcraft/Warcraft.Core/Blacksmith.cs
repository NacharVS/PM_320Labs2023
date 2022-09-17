using Warcraft.Core.BaseClasses;

namespace Warcraft.Core;

public class Blacksmith : Unit
{
    private List<Military> _units;
    private const int ArmorIncreaseValue = 2;
    private const int DamageIncreaseValue = 20;
    private const int BowIncreaseValue = 10;

    public Blacksmith(IEventLogger logger, int health, int cost, string name,
        int level, List<Military> units) : base(logger, health, cost, name,
        level)
    {
        _units = units;
    }
    
    public Blacksmith(IEventLogger logger, int health, int cost, string name,
        int level, params Military[] units) : base(logger, health, cost, name,
        level)
    {
        _units = units.ToList();
    }

    public void UpgradeArmor()
    {
        BeforeAction();
        foreach (var unit in _units)
        {
            unit.IncreaseArmor(ArmorIncreaseValue);
            Log($"Увеличил броню {unit.Name} на {ArmorIncreaseValue}");
        }
    }

    public void UpgradeWeapon()
    {
        BeforeAction();
        foreach (var unit in _units)
        {
            if (unit is Footman f)
            {
                f.UpgradeWeapon(DamageIncreaseValue);
                Log($"Увеличил урон {f.Name} на {DamageIncreaseValue}");
            }
        }
    }

    public void UpgradeBow()
    {
        BeforeAction();
        foreach (var unit in _units)
        {
            if (unit is Archer arr)
            {
                arr.UpgradeBow(BowIncreaseValue);
                Log(
                    $"Увеличил количество стрел у {arr.Name} на {BowIncreaseValue}");
            }
        }
    }

    private void BeforeAction()
    {
        _units = _units.Where(x => !x.IsDestroyed).ToList();
        
        if (_units.Count == 0)
        {
            Log("Не может ничего сделать");
        }
    }
}