using System.Collections.Generic;
using System.Threading;

namespace RTS.Core.Annotations.Units
{
    public class BlackSmith
    {
        public List<Unit> UpgradeArrow(List<Unit> units)
        {
            foreach (var entity in units)
            {
                if (entity.GetType() == typeof(Archer))
                {
                    Thread.Sleep(3000);
                    ((Archer)entity).ArrowCount++;
                }
            }
            return new List<Unit>();
        }
        
        public List<Unit> UpgradeWeapon(List<Unit> units)
        {
            foreach (var entity in units)
            {
                if (entity.GetType() == typeof(Military))
                {
                    Thread.Sleep(3000);
                    ((Military)entity).Damage++;
                }
            }
            return new List<Unit>();
        }
        
        public List<Unit> UpgradeBow(List<Unit> units)
        {
            foreach (var entity in units)
            {
                if (entity.GetType() == typeof(Archer))
                {
                    Thread.Sleep(3000);
                    ((Archer)entity).Damage++;
                }
            }
            return new List<Unit>();
        }
    }
}