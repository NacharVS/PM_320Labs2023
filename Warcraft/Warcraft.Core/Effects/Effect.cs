namespace Warcraft.Core.Effects;

public class Effect
{
    public string Name { get; set; }
    public int Damage { get; set; }
    public int Duration { get; set; }
    public string Message { get; set; }

    public string LogMessage => string.Format(Message, Damage);
}