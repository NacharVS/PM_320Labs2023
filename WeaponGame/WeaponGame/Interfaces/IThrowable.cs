namespace WeaponGame
{
    public interface IThrowable
    {
        int ThrowDamage { get; set; }

        public void Throw();
    }
}