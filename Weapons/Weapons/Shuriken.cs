class Shuriken : IThrowable
{
    public int ThrowDamage => 2;

    public void Throw()
    {
        Console.WriteLine($"Shuriken inflicted of {ThrowDamage} throwable damage");
    }
}
