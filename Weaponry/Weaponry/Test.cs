namespace Weaponry;

public interface IWorkerA { int DoWork(); }
public interface IWorkerB { int DoWork(); }


public class Test : IWorkerA, IWorkerB
{
    int IWorkerA.DoWork()
    {
        throw new NotImplementedException();
    }

    int IWorkerB.DoWork()
    {
        throw new NotImplementedException();
    }
}