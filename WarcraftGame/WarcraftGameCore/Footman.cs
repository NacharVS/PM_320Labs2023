namespace WarcraftGameCore
{
    public class Footman : Military
    {
        private bool _isBerserkerActivated;

        public Footman(string name) : base (700, 2, 1000, 20, name, 2000, 1100, 2, 2500) 
        {
            healthChangedEvent += Berserker;
        }

        private void Berserker(EventArgs args)
        {
            if (!this._isBerserkerActivated && 
                this.GetHealth() < this.GetMaxHp() * 0.2)
            {
                this._damage += this._damage * 2;
                this._isBerserkerActivated = true;

                Console.WriteLine($"{this.GetName()}: berserker activated!");
            }
            else if (this._isBerserkerActivated && 
                this.GetHealth() > this.GetMaxHp() * 0.2)
            {
                this._damage -= this._damage / 2;
                this._isBerserkerActivated = false;

                Console.WriteLine($"{this.GetName()}: berserker deactivated!");
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