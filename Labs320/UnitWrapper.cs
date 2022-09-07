using Warcraft.Core.BaseEntities;

namespace Labs320;

public class UnitWrapper
{
    public Military Entity { get; set; }
    public List<Military> Warriors { get; set; }

    public UnitWrapper(Military entity, List<Military> warriors)
    {
        Entity = entity;
        Warriors = warriors;
    }

    public void Run(object? state)
    {
        Random random = new Random();
        while (!Entity.IsDestroyed)
        {
            Unit target;
            while ((target = Warriors[random.Next(0, Warriors.Count)]) != Entity)
            {
                Entity.Attack(target);
            }
        }
    }
}