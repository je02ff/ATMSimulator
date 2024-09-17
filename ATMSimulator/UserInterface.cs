using System.Text;
using static ATMSimulator.Validate;

namespace ATMSimulator;

public class UserInterface
{
    private static int _origRow;
    private static int _origCol;
    private static readonly int _boxWidth = 100;
    private static readonly int _boxHeight = 30;
    private static string _title = "-^-$- ATM -$-^-";
    private static string _loginPrompt = "Please enter 6-digit account number: ";
    private ConsoleColor _titleTextColor = ConsoleColor.Black;
    private ConsoleColor _titleBackgroundColor = ConsoleColor.DarkGreen;

    public void DisplayUi()
    {
        //TODO: draw box with title screen at top Below title bar, prompt input for acct#
        DrawBox(_boxWidth, _boxHeight);
        Login();
        while (true)
        {
            string userInput;
        }
    }

    private void Login()
    {
        string userInput;
        int inputRow = 4;
        int inputCol = 2;
        bool isValidInput;

        do
        {
            // Clear previous input area
            WriteAt(new string(' ', _boxWidth - 4), inputCol, inputRow);

            // Display prompt
            WriteAt(_loginPrompt, inputCol, inputRow);

            // Set cursor position right after the prompt
            Console.SetCursorPosition(inputCol + _loginPrompt.Length, inputRow);

            // Read user input
            StringBuilder sb = new StringBuilder();
            ConsoleKeyInfo i = default;
            int maxLength = 6;

            // while ((Console.ReadKey().Key) != ConsoleKey.Enter)   // 13 = enter key (or other breaking condition)
            // {
            //     if (++count > 5)  break;
            //     sb.Append (i.KeyChar);
            // }

            while(true) {
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
            
            // userInput = Console.ReadLine() ?? "";

            // Clear the area where the error message would appear
            WriteAt(new string(' ', 6), inputCol + _loginPrompt.Length, inputRow);

            // Validate user input
            isValidInput = IsValidAccountNumber(sb.ToString());

            if (!isValidInput)
            {
                // Display invalid message
                InvalidText();
                Thread.Sleep(1000); // Delay before allowing new input
            }
        } while (!isValidInput);

        // Clear input area after successful login
        WriteAt(new string(' ', _boxWidth - 4), inputCol, inputRow);
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
        for (var i = 0; i < _boxWidth - 2; i++) WriteAt(Rectangle.hz, i + 1, 0);
        WriteAt(Rectangle.ur, _boxWidth, 0);
        for (var i = 0; i < 3; i++) WriteAt(new string(' ', _boxWidth), 1, i + 1);
        WriteAt(_title, _boxWidth / 2 - _title.Length / 2, 2);

        // Draw Sides
        for (var i = 0; i < _boxHeight - 1; i++) WriteAt(Rectangle.vt, 0, i + 1);
        for (var i = 0; i < _boxHeight - 1; i++) WriteAt(Rectangle.vt, _boxWidth, i + 1);

        //Draw Bottom
        WriteAt(Rectangle.ll, 0, _boxHeight);
        for (var i = 0; i < _boxWidth - 1; i++) WriteAt(Rectangle.hz, i + 1, _boxHeight);
        WriteAt(Rectangle.lr, _boxWidth, _boxHeight);

        // WriteAt("All done!", 10, 10);
        Console.BackgroundColor = defaultBackground;
        WriteAt("   ", 0, _boxHeight + 1);
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

    public void InvalidText()
    {
        string outputText = "Invalid account number.";
        Console.ForegroundColor = ConsoleColor.DarkRed;
        WriteAt(outputText, _loginPrompt.Length + 2, 4);
        Console.ResetColor();
    }
}