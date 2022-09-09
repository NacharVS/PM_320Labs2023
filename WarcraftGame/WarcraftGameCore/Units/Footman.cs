namespace WarcraftGameCore
{
    public class Footman : Military
    {
        private bool _isBerserkerActivated;

        public Footman(Logger logger, string name) : 
            base (logger, 700, 2, 1000, 20, name, 2000, 1100, 2,2500) 
        {
            healthChangedEvent += Berserker;
        }

        private void Berserker(EventArgs args)
        {
            if (!_isBerserkerActivated && 
                GetHealth() < GetMaxHp() * 0.2)
            {
                SetDamage(GetDamage() * 2);
                _isBerserkerActivated = true;

                Log($"{GetName()}: berserker activated!");
            }
            else if (_isBerserkerActivated && 
                GetHealth() > GetMaxHp() * 0.2)
            {
                SetDamage(GetDamage() / 2);
                _isBerserkerActivated = false;

                Log($"{GetName()}: berserker deactivated!");
            }
        }

        public void Stun()
        {
            if (CheckDied())
            {
                return;
            }

            Log("Unit stun!");
        }
    }
}