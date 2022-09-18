using System;
namespace InterfacesGame
{
    public interface IMeleeWeapon : IWeapon
    {
        public void Hit();

        int MeleeDamage { get; set; }

    }
}
