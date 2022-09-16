namespace WeaponGame
{
    public interface IRepairible
    {
        int Durability { get; set; }

        public void Repair();
    }
}