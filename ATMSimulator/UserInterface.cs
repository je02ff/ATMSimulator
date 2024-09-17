using System.Text;
using static ATMSimulator.Validate;

namespace ATMSimulator;

public class UserInterface
{
    private const int BoxWidth = 100;
    private const int BoxHeight = 30;
    private static int _origRow = Console.CursorTop;
    private static int _origCol = Console.CursorLeft;
    private static Writer _writer = new(_origRow, _origCol);
    private static string _title = "-^-$- ATM -$-^-";
    private static string _loginPrompt = "Please enter 6-digit account number: ";

    

    public void Display()
    {
        DrawBorderBox();
        Login();
        DrawOptions();
        
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
            _writer.WriteAt(new string(' ', BoxWidth - 4), inputCol, inputRow);
            _writer.WriteAt(_loginPrompt, inputCol, inputRow);
            Console.SetCursorPosition(inputCol + _loginPrompt.Length, inputRow);
            var inputUserAccount = GetUserInput(maxInputLength);
            _writer.WriteAt(new string(' ', 6), inputCol + _loginPrompt.Length, inputRow);
            isValidInput = IsValidAccountNumber(inputUserAccount);

            if (!isValidInput)
            {
                InvalidText();
                Thread.Sleep(1000);
            }
        } while (!isValidInput);

        _writer.WriteAt(new string(' ', BoxWidth - 4), inputCol, inputRow);
    }
    
    private static void InvalidText()
    {
        string outputText = "Invalid account number.";
        Console.ForegroundColor = ConsoleColor.DarkRed;
        _writer.WriteAt(outputText, _loginPrompt.Length + 2, 4);
        Console.ResetColor();
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
    
    

    private static void DrawOptions()
    {
        const int optionBoxWidth = 25;
        const int leftOptionStartX = 32;
        const int optionStartY = 7;
        const int  rightOptionStartX = 40+optionBoxWidth;

        //Left Side
        DrawOption("1. Balance", leftOptionStartX, optionStartY);
        DrawOption("2. Withdraw", leftOptionStartX, optionStartY*2);
        DrawOption("3. Transfer", leftOptionStartX, optionStartY*3);
        
        //Right Side
        DrawOption("4. Fast Cash", rightOptionStartX, optionStartY);
        DrawOption("5. Transactions", rightOptionStartX, optionStartY*2);
        DrawOption("6. Logout", rightOptionStartX, optionStartY*3);
    }

    private static void DrawOption(string title, int x, int y)
    {
        const int OptionBoxWidth = 25;
        const int OptionBoxHeight = 4;
        for (var i = 1; i < OptionBoxWidth; i++) _writer.WriteAt("-", i + x, y);
        for (var i = 1; i < OptionBoxWidth; i++) _writer.WriteAt("-", i + x, y + OptionBoxHeight);
        for (var i = 1; i < OptionBoxHeight; i++) _writer.WriteAt("|", x, y + i);
        for (var i = 1; i < OptionBoxHeight; i++) _writer.WriteAt("|", x + OptionBoxWidth, y + i);
        _writer.WriteAt(title, x + (OptionBoxWidth / 2 - title.Length / 2), y + OptionBoxHeight / 2);
    }

    private static void DrawBorderBox()
    {
        // Clear the screen, then save the top and left coordinates.
        Console.Clear();

        var defaultBackground = Console.BackgroundColor;
        var defaultForeground = Console.ForegroundColor;
        Console.BackgroundColor = ConsoleColor.DarkGreen;
        Console.ForegroundColor = ConsoleColor.Black;

        // Draw Title Header
        _writer.WriteAt(Rectangle.ul, 0, 0);
        for (var i = 0; i < BoxWidth - 2; i++) _writer.WriteAt(Rectangle.hz, i + 1, 0);
        _writer.WriteAt(Rectangle.ur, BoxWidth, 0);
        for (var i = 0; i < 3; i++) _writer.WriteAt(new string(' ', BoxWidth), 1, i + 1);
        _writer.WriteAt(_title, BoxWidth / 2 - _title.Length / 2, 2);

        // Draw Sides
        for (var i = 0; i < BoxHeight - 1; i++) _writer.WriteAt(Rectangle.vt, 0, i + 1);
        for (var i = 0; i < BoxHeight - 1; i++) _writer.WriteAt(Rectangle.vt, BoxWidth, i + 1);

        //Draw Bottom
        _writer.WriteAt(Rectangle.ll, 0, BoxHeight);
        for (var i = 0; i < BoxWidth - 1; i++) _writer.WriteAt(Rectangle.hz, i + 1, BoxHeight);
        _writer.WriteAt(Rectangle.lr, BoxWidth, BoxHeight);

        // WriteAt("All done!", 10, 10);
        Console.BackgroundColor = defaultBackground;
        _writer.WriteAt("   ", 0, BoxHeight + 1);
        Console.ForegroundColor = defaultForeground;
    }

}