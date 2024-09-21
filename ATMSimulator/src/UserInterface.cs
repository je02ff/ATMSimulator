using System.Runtime.InteropServices;
using static ATMSimulator.Validate;

namespace ATMSimulator;

public static class UserInterface
{
    public static int OrigRow = Console.CursorTop;
    public static int OrigCol = Console.CursorLeft;
    public static int BoxWidth => 100;
    public static int BoxHeight => 30;
    private static string _title = "-^-$- ATM -$-^-";

    public static void Start()
    {
        [DllImport("libc")]
        static extern int system(string exec);
        system(@"printf '\e[8;35;100t'"); //adjust terminal window size.
        system(@"printf '\e[3;0;0t'"); // moves terminal to top left
        InitView();
    }

    public static void DrawOptions()
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
        const int optionBoxWidth = 25;
        const int optionBoxHeight = 4;
        for (var i = 1; i < optionBoxWidth; i++) ConsoleUtils.WriteAt("-", i + x, y);
        for (var i = 1; i < optionBoxWidth; i++) ConsoleUtils.WriteAt("-", i + x, y + optionBoxHeight);
        for (var i = 1; i < optionBoxHeight; i++) ConsoleUtils.WriteAt("|", x, y + i);
        for (var i = 1; i < optionBoxHeight; i++) ConsoleUtils.WriteAt("|", x + optionBoxWidth, y + i);
        ConsoleUtils.WriteAt(title, x + (optionBoxWidth / 2 - title.Length / 2), y + optionBoxHeight / 2);
    }

    public static void InitView()
    {
        // Clear the screen, then save the top and left coordinates.
        Console.Clear();

        var defaultBackground = Console.BackgroundColor;
        var defaultForeground = Console.ForegroundColor;
        Console.BackgroundColor = ConsoleColor.DarkGreen;
        Console.ForegroundColor = ConsoleColor.Black;

        // Draw Title Header
        ConsoleUtils.WriteAt(Rectangle.ul, 0, 0);
        for (var i = 0; i < BoxWidth - 2; i++) ConsoleUtils.WriteAt(Rectangle.hz, i + 1, 0);
        ConsoleUtils.WriteAt(Rectangle.ur, BoxWidth, 0);
        for (var i = 0; i < 3; i++) ConsoleUtils.WriteAt(new string(' ', BoxWidth), 1, i + 1);
        ConsoleUtils.WriteAt(_title, BoxWidth / 2 - _title.Length / 2, 2);

        // Draw Sides
        for (var i = 0; i < BoxHeight - 1; i++) ConsoleUtils.WriteAt(Rectangle.vt, 0, i + 1);
        for (var i = 0; i < BoxHeight - 1; i++) ConsoleUtils.WriteAt(Rectangle.vt, BoxWidth, i + 1);

        //Draw Bottom
        ConsoleUtils.WriteAt(Rectangle.ll, 0, BoxHeight);
        for (var i = 0; i < BoxWidth - 1; i++) ConsoleUtils.WriteAt(Rectangle.hz, i + 1, BoxHeight);
        ConsoleUtils.WriteAt(Rectangle.lr, BoxWidth, BoxHeight);

        // WriteAt("All done!", 10, 10);
        Console.BackgroundColor = defaultBackground;
        ConsoleUtils.WriteAt("   ", 0, BoxHeight + 1);
        Console.ForegroundColor = defaultForeground;
    }

}