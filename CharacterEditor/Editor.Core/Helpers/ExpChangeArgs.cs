namespace Editor.Core.Helpers;

public class ExpChangeArgs : EventArgs
{
    public int Amount { get; set; }

    public ExpChangeArgs(int val)
    {
        Amount = val;
    }
}