using RTS.Core.BaseEntities;

namespace RTS.Core.Effects;

public class TemporaryEffect
{
    public Unit Target { get; set; }
    public TimeSpan Duration { get; set; }
    public TimeSpan Interval { get; set; }
    public Action<Unit> Effect { get; set; }
    private DateTime _startTime;

    public TemporaryEffect(Unit target, TimeSpan duration, TimeSpan interval, Action<Unit> effect)
    {
        Target = target;
        Duration = duration;
        Interval = interval;
        Effect = effect;
    }

    public void Append(object? state)
    {
        _startTime = DateTime.Now;
        while (DateTime.Now - _startTime < Duration && !Target.IsDestroyed)
        {
            Effect.Invoke(Target);
            Thread.Sleep(Interval);
        }
    }
}