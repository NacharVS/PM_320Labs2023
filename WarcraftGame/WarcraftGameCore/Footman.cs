namespace WarcraftGameCore
{
    public class Footman : Military
    {

        public Footman(string name) : base (700, 2, 1000, 20, name, 2000, 1100, 2) {}

        public void Berserker(Unit unit)
        {
            if (this.CheckDied())
            {
                return;
            }

            if (unit is Military milUnit)
            {
                milUnit.SetAttackedSpeed(milUnit.GetAttackedSpeed() + 4);
            }
            else if (unit is GuardTower gtUnit)
            {
                gtUnit.SetAttackedSpeed(gtUnit.GetAttackedSpeed() + 4);
            }
        }

        public void Stun()
        {
            if (this.CheckDied())
            {
                return;
            }

            Console.WriteLine("Unit stun!");
        }
    }
}