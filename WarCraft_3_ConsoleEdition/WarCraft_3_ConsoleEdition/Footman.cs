namespace WarCraft_3_ConsoleEdition
{
    class Footman : Military
    {
        public bool isBerserk;

        public delegate void BerserkActivatedDelegate(string message);
        public event BerserkActivatedDelegate? BerserkActivatedEvent;

        public void Berserker()
        {
            if (!isBerserk)
            {
                damage *= 2;
            }

            isBerserk = true;
            BerserkActivatedEvent?.Invoke("BERSEKER ACTIVATED ALL ENEMY PLEASE RUN!!!");
        }

        void DisplayMessage(string message) => Console.WriteLine(message);

        public void Stun(Movable movable)
        {
            movable.timeWithoutAttack += 5;
        }

        public Footman(int damage, int attackSpeed, int armor, int speed, int health,
            int cost, string name, int level) : base(damage, attackSpeed, armor, speed, health, cost, name, level) 
        {
            BerserkActivatedEvent += DisplayMessage;
        }
    }

}
