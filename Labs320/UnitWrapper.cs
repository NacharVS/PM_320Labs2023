using Warcraft.Core.BaseEntities;
using Warcraft.Core.Units;

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
                if (Entity.GetType() == typeof(Mage) && ((Mage)Entity).Mana >= 20)
                {
                    switch (random.Next(1,4))
                    {
                        case 1:
                            ((Mage)Entity).Fireball(target);
                            break;
                        case 2:
                            ((Mage)Entity).Heal(Entity);
                            break;
                        case 3:
                            ((Mage)Entity).Blizzard(target);
                            break;
                    }
                }
                else
                {
                    Entity.Attack(target);   
                }
            }
        }
    }
}