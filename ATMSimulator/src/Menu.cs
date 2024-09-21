namespace ATMSimulator;

public class Menu
{
    private static string _loginPrompt = "  Please enter 6-digit account number: ";

    public static string LoginPrompt()
    {
        Console.Write(Rectangle.vt + _loginPrompt);
        var input = Console.ReadLine() ?? "";
        
        return input;
    }
}