namespace Core.Interfaces;

public interface IHaveAutoMode : IRangedWeapon, IReloadable
{
    public void AutoModeShoot();
}