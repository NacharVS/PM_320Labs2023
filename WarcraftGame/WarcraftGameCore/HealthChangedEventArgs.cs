namespace WarcraftGameCore
{
    public class HealthChangedEventArgs : EventArgs
    {
        public double PreviosHp { get; }
        public double CurrentHp { get; }

        public HealthChangedEventArgs(double previosHp, double currentHp)
        {
            PreviosHp = previosHp;
            CurrentHp = currentHp;
        }
    }
}