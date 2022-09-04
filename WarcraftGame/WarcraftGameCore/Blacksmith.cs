namespace WarcraftGameCore
{
    public class Blacksmith : Moveble
    {
        public Blacksmith(string name) : base(20, name, 2000, 1100, 2) { }

        public void UpgradeArmor(List<Unit> units)
        {
            foreach (var unit in units)
            {
                if (unit is Military milUnit)
                {
                    milUnit.UpgradeArmor();
                }
            }
        }

        public void UpgradeBow(List<Unit> units)
        {
            foreach (var unit in units)
            {
                if (unit is Archer archUnit)
                {
                    archUnit.UpgradeBow();
                }
            }
        }

        public void UpgradeArrow(List<Unit> units)
        {
            foreach (var unit in units)
            {
                if (unit is Archer archUnit)
                {
                    archUnit.UpgradeArrow();
                }
            }
        }
    }
}
