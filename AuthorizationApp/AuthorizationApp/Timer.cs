namespace AuthorizationApp;

public class Timer
{
    private bool _started = false;
    public int Seconds { get; private set; }
    public Action Action { get; set; }
    public async Task StartAsync(int seconds)
    {
        if (_started)
            return;
        
        _started = true;
        
        Seconds = seconds;
        while (Seconds > 0 && _started)
        {
            Seconds--;
            Action();
            await Task.Delay(1000);
        }

        _started = false;
    }

    public void AddSeconds(int seconds)
    {
        Seconds += seconds;
    }

    public void Stop()
    {
        Seconds = 0;
        _started = false;
    }
}