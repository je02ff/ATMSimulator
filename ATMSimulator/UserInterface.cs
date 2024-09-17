using System.Text;
using static ATMSimulator.Validate;

namespace ATMSimulator;

public class UserInterface
{
    private static int _origRow;
    private static int _origCol;
    private const int BoxWidth = 100;
    private const int BoxHeight = 30;
    private const int OptionBoxWidth = 25;
    private const int OptionBoxHeight = 4;
    private static string _title = "-^-$- ATM -$-^-";
    private static string _loginPrompt = "Please enter 6-digit account number: ";

    public void DisplayUi()
    {
        //TODO: draw box with title screen at top Below title bar, prompt input for acct#
        DrawBox(BoxWidth, BoxHeight);
        Login();
        DrawOption("1. Balance", OptionBoxWidth, 5);
        DrawOption("1. Balance", OptionBoxWidth*2+10, 5);
        while (true)
        {
            string userInput;
        }
    }

    private void Login()
    {
        GetUserAccountNumber();
        // GetUserPin();
        // AuthenticateUser();
    }

    private void GetUserAccountNumber()
    {
        const int inputRow = 4;
        const int inputCol = 2;
        const int maxInputLength = 6;
        bool isValidInput;

        do
        {
            WriteAt(new string(' ', BoxWidth - 4), inputCol, inputRow);
            WriteAt(_loginPrompt, inputCol, inputRow);
            Console.SetCursorPosition(inputCol + _loginPrompt.Length, inputRow);
            var inputUserAccount = GetUserInput(maxInputLength);
            WriteAt(new string(' ', 6), inputCol + _loginPrompt.Length, inputRow);
            isValidInput = IsValidAccountNumber(inputUserAccount);

            if (!isValidInput)
            {
                InvalidText();
                Thread.Sleep(1000);
            }
        } while (!isValidInput);

        WriteAt(new string(' ', BoxWidth - 4), inputCol, inputRow);
    }

    private static string GetUserInput(int maxLength)
    {
        StringBuilder sb = new StringBuilder();

        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.Enter)
            {
                Console.Beep();
                break;
            }

            sb.Append(keyInfo.KeyChar);
            if (sb.Length >= maxLength)
            {
                Console.Beep();
                break;
            }
        }

        return sb.ToString();
    }

    private static void DrawOption(string title, int x, int y)
    {
        

        for (var i = 1; i < OptionBoxWidth; i++) WriteAt("-", i + x, y);
        for (var i = 1; i < OptionBoxWidth; i++) WriteAt("-", i + x, y + OptionBoxHeight);
        for (var i = 1; i < OptionBoxHeight; i++) WriteAt("|", x, y + i);
        for (var i = 1; i < OptionBoxHeight; i++) WriteAt("|", x + OptionBoxWidth, y + i);
        WriteAt(title, x + (OptionBoxWidth / 2 - title.Length / 2), y + OptionBoxHeight / 2);
    }

    private static void DrawBox(int width, int height)
    {
        // Clear the screen, then save the top and left coordinates.
        Console.Clear();
        _origRow = Console.CursorTop;
        _origCol = Console.CursorLeft;

        var defaultBackground = Console.BackgroundColor;
        var defaultForeground = Console.ForegroundColor;
        Console.BackgroundColor = ConsoleColor.DarkGreen;
        Console.ForegroundColor = ConsoleColor.Black;

        // Draw Title Header
        WriteAt(Rectangle.ul, 0, 0);
        for (var i = 0; i < BoxWidth - 2; i++) WriteAt(Rectangle.hz, i + 1, 0);
        WriteAt(Rectangle.ur, BoxWidth, 0);
        for (var i = 0; i < 3; i++) WriteAt(new string(' ', BoxWidth), 1, i + 1);
        WriteAt(_title, BoxWidth / 2 - _title.Length / 2, 2);

        // Draw Sides
        for (var i = 0; i < BoxHeight - 1; i++) WriteAt(Rectangle.vt, 0, i + 1);
        for (var i = 0; i < BoxHeight - 1; i++) WriteAt(Rectangle.vt, BoxWidth, i + 1);

        //Draw Bottom
        WriteAt(Rectangle.ll, 0, BoxHeight);
        for (var i = 0; i < BoxWidth - 1; i++) WriteAt(Rectangle.hz, i + 1, BoxHeight);
        WriteAt(Rectangle.lr, BoxWidth, BoxHeight);

        // WriteAt("All done!", 10, 10);
        Console.BackgroundColor = defaultBackground;
        WriteAt("   ", 0, BoxHeight + 1);
        Console.ForegroundColor = defaultForeground;
    }

    private static void WriteAt(string s, int x, int y)
    {
        try
        {
            Console.SetCursorPosition(_origCol + x, _origRow + y);
            Console.Write(s);
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.Clear();
            Console.WriteLine(e.Message);
        }
    }

    private static void InvalidText()
    {
        string outputText = "Invalid account number.";
        Console.ForegroundColor = ConsoleColor.DarkRed;
        WriteAt(outputText, _loginPrompt.Length + 2, 4);
        Console.ResetColor();
    }
}