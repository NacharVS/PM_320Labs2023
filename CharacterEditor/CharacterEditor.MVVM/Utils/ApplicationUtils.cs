namespace CharacterEditor.MVVM.Utils;

public static class ApplicationUtils
{
    public static string GetSign(int number)
    {
        return number > 0 ? "+" : "-";
    }
    
    public static string GetSign(double number)
    {
        return number > 0 ? "+" : "-";
    }
}