using RTS.Core.BaseEntities;
using RTS.Core.Units;

namespace RTS.ConsoleGame;

public class UnitWrapper
{
    public Military Entity { get; set; }
    public List<Military> Units { get; set; }

    public UnitWrapper(Military entity, List<Military> units)
    {
        Entity = entity;
        Units = units;
    }

    public void Run(object? state)
    {
        Random rnd = new Random();
        while (!Entity.IsDestroyed)
        {
            Unit target;
            while ((target = Units[rnd.Next(0, Units.Count)]) != Entity)
            {
                if (Entity.GetType() == typeof(Mage))
                {
                    var spellsList = ((Mage)Entity).GetSpellsList().ToList();
                    spellsList.ElementAt(rnd.Next(0, spellsList.Count)).Invoke(target);
                }
                else if (Entity.GetType() == typeof(Dragon))
                {
                    var spellsList = ((Dragon)Entity).GetSpellsList().ToList();
                    spellsList.ElementAt(rnd.Next(0, spellsList.Count)).Invoke(target);
                }
                else
                {
                    Entity.Attack(target);
                }
            }
        }
    }
}