namespace Core.Interfaces;

public interface IHaveSingleMode : IRangedWeapon, IReloadable
{
    public void SingleShoot();
}